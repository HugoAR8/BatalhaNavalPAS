using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{

    private float xmouseSensitivity = 75f;
    private float ymouseSensitivity = 75f;

    public Transform playerBody;

    private Ship activeShip;

    float xRotation = 0f;
    float yRotation = 0f;

    private void Start()
    {
        activeShip = PlayerMovement.curShip.GetComponent<Ship>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * xmouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * ymouseSensitivity * Time.deltaTime;
        



        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation -= mouseX;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);


        //rotação dos canhões
        if (PlayerMovement.gameOver == false)
        {
            for (int i = 0; i < activeShip.getCannonsQtd(); i++)
            {
                activeShip.cannons[i].transform.localRotation = Quaternion.Euler(xRotation, -yRotation, 0f);
            }
        }

        

    }
}
