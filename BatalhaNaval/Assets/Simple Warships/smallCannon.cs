using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallCannon : MonoBehaviour, Cannon
{
    [SerializeField] private Transform cannonFirePoint;
    [SerializeField] private GameObject bullet;
    private float randomShootAngleX;
    private float randomShootAngleY;
    private float randomShootAngleZ;
    private Vector3 shotAngle;
    private Quaternion shotRotation;


    public void Shoot()
    {
        //Instanciar tiro

        randomShootAngleY = Random.Range(-2,2);
        randomShootAngleZ = Random.Range(-2, 2);
        randomShootAngleX = Random.Range(-2, 2);
        shotAngle = new Vector3(randomShootAngleX, randomShootAngleY, randomShootAngleZ);
        shotRotation.eulerAngles = shotAngle;
        Instantiate<GameObject>(bullet, cannonFirePoint.position, cannonFirePoint.rotation * shotRotation);

    }
}
