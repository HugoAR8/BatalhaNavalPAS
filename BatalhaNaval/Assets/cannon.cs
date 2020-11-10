using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] protected float life = 25;
    [SerializeField] protected Transform cannonFirePoint;
    [SerializeField] protected GameObject bullet;


    public void takeDamage(float damage)
    {
        life -= damage;
    }

    public void shoot()
    {
        //Instanciar tiro
        Instantiate<GameObject>(bullet, cannonFirePoint.position, cannonFirePoint.rotation);
    }
}
