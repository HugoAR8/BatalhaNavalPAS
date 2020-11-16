using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;


    public static GameObject curShip;
    [SerializeField] private GameObject[] allShips;


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
        if(gameControl.curShip == "Corvette")
        {
            controller.radius = 4f;
            controller.height = 3.87f;
            curShip = Instantiate(allShips[0], transform.position, transform.rotation);
        }
        else if(gameControl.curShip == "Frigate")
        {
            controller.radius = 3f;
            controller.height = 2.18f;
            curShip = Instantiate(allShips[1], transform.position, transform.rotation);
        }
        else if(gameControl.curShip == "Cruiser")
        {
            controller.radius = 4f;
            controller.height = 3.87f;
            curShip = Instantiate(allShips[2], transform.position, transform.rotation);
        }
        else if(gameControl.curShip == "Destroyer")
        {
            controller.radius = 2.5f;
            controller.height = 0f;
            curShip = Instantiate(allShips[3], transform.position, transform.rotation);
        }
        else
        {
            controller.radius = 2.5f;
            controller.height = 0f;
            curShip = Instantiate(allShips[4], transform.position, transform.rotation);
        }
        curShip.transform.parent = this.transform;
        speed = curShip.GetComponent<Ship>().speed;
        backwardsSpeed = speed / 3;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            curShip.GetComponent<Ship>().Attack();
        }
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
