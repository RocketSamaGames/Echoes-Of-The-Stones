using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Variable para la sensibilidad de la cámara
    public float mouseSensitivity = 100f;

    // Obtenemos el gameobject de nuestro jugador. Como es pública, lo añadimos desde Unity
    public Transform playerBody;

    private float rotationX = 0f;

    void Start()
    {
        // Limitamos el movimiento del ratón a la ventana Game
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Variables que almacenan el movimiento del ratón en el eje X e Y. Se multiplican por la sensibilidad
        // y por Time.deltaTime (esto último sirve para que el comportamiento no varíe en distintos ordenadores por los FPS)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        #region HorizontalRotation
        // Con esto hacemos que el personaje gire en el eje horizontal (es decir, hacia arriba/abajo)
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90, 90); // Limitamos el movimiento de la cámara para que como máximo gire a 90 o -90 grados
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        #endregion

        #region VerticalRotation
        // Con esto hacemos que el personaje gire en el eje vertical (es decir, hacia izquierda/derecha)
        playerBody.Rotate(Vector3.up * mouseX);
        #endregion
    }
}
