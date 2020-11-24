using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    //Sensibilidade da camera
    private float xmouseSensitivity = 75f;
    private float ymouseSensitivity = 75f;

    //Corpo do jogador
    public Transform playerBody;

    //navio do jogador
    private Ship activeShip;

    //rotação dos canhões do jogador
    float xRotation = 0f;
    float yRotation = 0f;

    //chamada ao inicio de cada cena
    private void Start()
    {
        //Busca o navio atual do jogador
        activeShip = PlayerMovement.curShip.GetComponent<Ship>();
    }

    // Update is called once per frame
    void Update()
    {
        //Posições do mouse
        float mouseX = Input.GetAxis("Mouse X") * xmouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * ymouseSensitivity * Time.deltaTime;
        


        //Calculo de rotação do mouse
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
