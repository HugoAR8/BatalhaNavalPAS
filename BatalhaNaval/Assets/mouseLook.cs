using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{

    private float xmouseSensitivity = 100f;
    private float ymouseSensitivity = 50f;

    public Transform playerBody;

    //Fazer função que pega o script do navio que está ativo no momento
    public Ship playerShip;


    float xRotation = 0f;
    float yRotation = 0f;


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
        for(int i = 0; i < playerShip.getCannonsQtd(); i ++)
        {
            playerShip.cannons[i].transform.localRotation = Quaternion.Euler(xRotation, -yRotation, 0f);
        }

        

    }
}
