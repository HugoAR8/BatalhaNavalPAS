﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frigate : Ship
{
    private void Update()
    {
        if (life <= 0)
        {
            Destroyed();
        }
    }

    public override void underAttack(float damage)
    {
        life -= damage;
    }

    public override void Attack()
    {

        for (int i = 0; i < getCannonsQtd(); i++)
        {
            cannons[i].GetComponent<Cannon>().shoot();
        }

    }
}