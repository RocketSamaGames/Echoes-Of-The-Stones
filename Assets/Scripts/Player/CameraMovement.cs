using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector2 sensitivity;

    [SerializeField] private Transform gameCamera;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");

        float mouseY = Input.GetAxis("Mouse Y");

        if (mouseX != 0)
        {
            transform.Rotate(Vector3.up * mouseX * sensitivity.x);
        }

        if (mouseY != 0)
        {
            float angle = (gameCamera.localEulerAngles.x - mouseY * sensitivity.y + 360) % 360;
            if (angle > 180)
            {
                angle -= 360;
            }

            angle = Mathf.Clamp(angle, -90, 80);
            
            gameCamera.localEulerAngles = Vector3.right * angle;
        }
    }
}
