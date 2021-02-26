using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialController : MonoBehaviour
{
    [SerializeField]
    private float notchAngle;
    [SerializeField]
    private bool isSelected;
    private Vector2 mousePosition;
    private Vector2 inputVector;

    public void OnMovement(InputValue value)
    {
        inputVector = value.Get<Vector2>();
        
        if (isSelected)
        {
            Vector3 angle = gameObject.transform.rotation.eulerAngles;

            if (inputVector.x < 0)
            {
                gameObject.transform.Rotate(0, -notchAngle * inputVector.x, 0, Space.Self);
            }
            else
            {
                gameObject.transform.Rotate(0, notchAngle * inputVector.x, 0, Space.Self);
            }
        }
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
