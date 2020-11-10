using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{

    public float mouseSensitivity = 25f;

    public Transform playerBody;

    //Fazer função que pega o script do navio que está ativo no momento
    public Ship playerShip;


    float xRotation = 0f;
    float yRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        float boatX = Input.GetAxis("Horizontal") * mouseSensitivity * Time.deltaTime;

        if(Input.GetMouseButtonDown(0))
        {
            for(int i = 0; i < playerShip.getCannonsQtd(); i++)
            {
                playerShip.cannons[i].GetComponent<Cannon>().shoot();
            }
        }

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation -= mouseX;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation,-yRotation,0f);
        for(int i = 0; i < playerShip.getCannonsQtd(); i ++)
        {
            playerShip.cannons[i].transform.localRotation = Quaternion.Euler(xRotation, -yRotation, 0f);
        }

        playerBody.Rotate(Vector3.up * boatX);

    }
}
