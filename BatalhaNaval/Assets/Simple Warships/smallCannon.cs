﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallCannon : MonoBehaviour, Cannon
{
    //Posição que o tiro sera instanciado
    [SerializeField] private Transform cannonFirePoint;

    //Tiro
    [SerializeField] private GameObject bullet;

    //Angulo aleatorio X
    private float randomShootAngleX;

    //Angulo aleatorio Y
    private float randomShootAngleY;

    //Angulo aleatorio Z
    private float randomShootAngleZ;

    // Angulo do tiro
    private Vector3 shotAngle;

    //Rotação do tiro
    private Quaternion shotRotation;



    //Função de atirar do canhão
    public void Shoot()
    {

        //Os canhões pequenos diferentemente dos grandes e médios tem a habilidade de instanciar 1
        // balas ao invés de 2/3

        //Definindo a aleatoriedade do angulo do tiro, para que ele não vão simplesmente em linha reta
        randomShootAngleY = Random.Range(-2,2);
        randomShootAngleZ = Random.Range(-2, 2);
        randomShootAngleX = Random.Range(-2, 2);
        shotAngle = new Vector3(randomShootAngleX, randomShootAngleY, randomShootAngleZ);
        shotRotation.eulerAngles = shotAngle;
        //Instanciando o tiro na posição que foi definida anteriormente
        Instantiate<GameObject>(bullet, cannonFirePoint.position, cannonFirePoint.rotation * shotRotation);

    }
}
