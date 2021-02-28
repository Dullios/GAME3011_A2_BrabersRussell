using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialController : MonoBehaviour
{
    [Header("Rotation Properties")]
    [SerializeField]
    private float notchAngle;
    [SerializeField]
    private float duration;
    [SerializeField]
    private bool isRotating;

    [SerializeField]
    private int correctOrientation;
    [SerializeField]
    private int currentOrientation = 0;

    [Header("Input Properties")]
    [SerializeField]
    private bool isSelected;
    private Vector2 mousePosition;
    [SerializeField]
    private Vector2 inputVector;

    private void Start()
    {
        correctOrientation = Random.Range(0, 10);
    }

    public void OnMovement(InputValue value)
    {
        inputVector = value.Get<Vector2>();

        if (isSelected && !isRotating)
        {
            if (inputVector.x < 0)
                StartCoroutine(RotateRoutine(true));
            else if (inputVector.x > 0)
                StartCoroutine(RotateRoutine(false));
        }
    }

    IEnumerator RotateRoutine(bool isLeft)
    {
        isRotating = true;
        float startRotation = transform.eulerAngles.x;
        float endRotation = isLeft ? startRotation + notchAngle : startRotation - notchAngle;
        float t = 0.0f;
        
        while (t < duration)
        {
            t += Time.deltaTime;
            float rotation = Mathf.Lerp(startRotation, endRotation, t / duration) % notchAngle;
            transform.eulerAngles = new Vector3(rotation, -90, -90);
            yield return null;
        }

        currentOrientation += isLeft ? 1 : -1;

        if (currentOrientation > 9)
            currentOrientation = 0;
        else if (currentOrientation < 0)
            currentOrientation = 9;

        isRotating = false;
    }

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
            isSelected = true;
        }
    }

    public void OnClickRelease(InputValue value)
    {
        isSelected = false;
    }
}
