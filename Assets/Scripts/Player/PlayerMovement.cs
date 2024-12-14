using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public Transform groundCheck;
    public LayerMask groundMask;
    public AudioSource steps;

    [SerializeField] private float speed = 10f;
    [SerializeField] private float sphereRadius = 0.3f;

    private float gravity = -9.81f;
    private Vector3 velocity;
    private bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
        
        if (characterController.velocity.magnitude > 0 && isGrounded)
        {
            if (!steps.isPlaying)
            {
                steps.Play();
            }
        }
        else
        {
            steps.Pause();
        }
    }
}
