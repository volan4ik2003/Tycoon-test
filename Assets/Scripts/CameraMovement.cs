using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovement : MonoBehaviour
{
    private Vector3 _lastMousePosition;
    private Camera _camera;
    private Vector3 _velocity;
    private bool _canMove = true;

    private void Start()
    {
       _camera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        CheckMovementInput();
    }

    private bool IsMouseOverUi()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    private void CheckMovementInput()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            _lastMousePosition = Input.mousePosition;
            _canMove = !IsMouseOverUi();
            _velocity = Vector3.zero;
        }

        if (!Input.GetMouseButton(0))
        {
            ApplyInertia();
            return;
        }
        else if (Input.GetMouseButton(0) && _canMove)
        {
            Vector3 mouseWorldPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 lastWorldPoint = _camera.ScreenToWorldPoint(_lastMousePosition);

            Vector3 delta = mouseWorldPoint - lastWorldPoint;

            _lastMousePosition = Input.mousePosition;

            _camera.transform.position -= delta / 2;
            _velocity = delta / Time.deltaTime;

        }
    }

    private void ApplyInertia()
    {
        if (_velocity != Vector3.zero)
        {
            _velocity *= 0.98f;
            _camera.transform.position -= _velocity * Time.deltaTime;
        }
    }
}
