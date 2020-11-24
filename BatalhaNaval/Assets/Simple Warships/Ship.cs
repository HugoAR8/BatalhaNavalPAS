using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ship : MonoBehaviour
{
    //Vida do navio
    protected float life = 0;
    protected float maxLife;
    public bool isDead = false;

    public int coinDrops = 0;

    //Velocidade do navio
    public float speed;
    protected float damagedSpeed;


    //Lista de canhões do navio
    public GameObject[] cannons;

    // Start is called before the first frame update
    void Start()
    {
        life = maxLife;
        damagedSpeed = speed / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0 )
        {
            isDead = true;
            Destroyed();
        }
    }

    public abstract void Attack();

    public abstract void underAttack(float damage);

    public int getCannonsQtd(){
        return cannons.Length;
    }

    public virtual void takeDamage(float damage)
    {
        life -= damage;
    }

    public virtual void Destroyed()
    {
        gameControl.coins += coinDrops;
        Destroy(gameObject);
    }

}
