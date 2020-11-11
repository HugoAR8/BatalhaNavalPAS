using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    private float speed = 120f;
    private float backwardsSpeed = 40f;

    public Vector3 velocity;
    private float gravity = -90.81f;

    public Transform groundCheck;
    public float groundDistance = 4f;
    public LayerMask groundMask;

    private bool isGrounded;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        //Gravidade
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -9f;
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        //Movimento
        float boatX = Input.GetAxis("Horizontal") *50 * Time.deltaTime;
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.forward * z;
        if (z > 0)
        {
            controller.Move(move * speed * Time.deltaTime);
        }
        else
        {
            controller.Move(move * backwardsSpeed * Time.deltaTime);
        }

        transform.Rotate(Vector3.up * boatX);





    }
}
