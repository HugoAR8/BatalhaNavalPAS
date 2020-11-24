using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : Ship
{

    private void Start()
    {
        life = 500;
    }
    private void Update()
    {

        if (life <= 0)
        {
            Destroyed();
        }
    }


    public override void Attack()
    {

        for (int i = 0; i < getCannonsQtd(); i++)
        {
            cannons[i].GetComponent<Cannon>().Shoot();
        }

    }
}
