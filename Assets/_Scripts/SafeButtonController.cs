using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SafeButtonController : MonoBehaviour
{
    private Vector2 mousePosition;

    public DialController[] dials;

    [Header("Sounds")]
    [SerializeField] private AudioSource locked;
    [SerializeField] private AudioSource opening;

    public void OnMousePosition(InputValue value)
    {
        mousePosition = value.Get<Vector2>();
    }

    public void OnClickDown(InputValue value)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        Physics.Raycast(ray, out hit, 20.0f);
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 1.0f);

        if (hit.transform != null && hit.transform.name == gameObject.name)
        {
            if (!GameManager.instance.gameOver && CheckDials())
            {
                GameManager.instance.GameOver(true);
                opening.Play();
            }
            else if (!GameManager.instance.gameOver)
                locked.Play();
        }
    }

    private bool CheckDials()
    {
        bool isAligned = true;

        foreach(DialController dc in dials)
        {
            if (!dc.gameObject.activeSelf)
                continue;

            if(dc.currentOrientation != dc.correctOrientation)
            {
                isAligned = false;
                break;
            }
        }

        return isAligned;
    }
}
