using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

// Este script contiene el funcionamiento del movimiento del player (movimiento y gravedad), así como sus efectos de sonido.
public class PlayerMovement : MonoBehaviour
{
    // Variables que se asignan desde Unity
    public CharacterController characterController;
    public Transform groundCheck; // Para asignar el elemento que detecta el suelo.
    public LayerMask groundMask; // Para asignar qué elemento es el suelo.
    public AudioSource steps; // Sonido de los pasos.

    [SerializeField] private float speed = 10f; // Velocidad de movimiento del player.
    [SerializeField] private float sphereRadius = 0.3f; // Para la detección del suelo.

    private float gravity = -9.81f; // Gravedad implementada para añadir mecánicas de salto en el futuro.
    private Vector3 velocity; // Para incrementar la velocidad de y a medida que va cayendo.
    private bool isGrounded; // Para determinar cuándo está en suelo.

    void Update()
    {
        // Determinamos cuándo el player está en el suelo.
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);

        // Si el player está en el suelo, impedimos que la velocidad de y aumente gradualmente.
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        // Si el player no está en el suelo, la velocidad de y aumenta gradualmente.
        else
        {
            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }

        // Obtenemos el valor de la entrada del eje horizontal (A / D | ← / →).
        float x = Input.GetAxis("Horizontal");
        // Obtenemos el valor de la entrada del eje vertical (W / S | ↑ / ↓).
        float z = Input.GetAxis("Vertical");

        // Movimiento del player
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
        
        if (characterController.velocity.magnitude > 0 && isGrounded) // Si el personaje se está moviendo y está en el suelo.
        {
            if (!steps.isPlaying) // Si no está sonando el audio de pasos.
            {
                steps.Play(); // Se reproduce el sonido de pasos.
            }
        }
        else
        {
            steps.Pause(); // En otro caso, deja de sonar el sonido de pasos.
        }
    }
}
