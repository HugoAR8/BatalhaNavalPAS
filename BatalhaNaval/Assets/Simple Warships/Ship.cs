using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ship : MonoBehaviour
{
    //Vida do navio
    protected float life = 0;
    [SerializeField] protected float maxLife;

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
            Destroyed();
        }
    }

    public virtual void underAttack(float damage)
    {
    }

    public virtual void Attack()
    {
    }

    public int getCannonsQtd(){
        return cannons.Length;
    }

    public void takeDamage(float damage)
    {
        life -= damage;
    }

    public void Destroyed()
    {
        Destroy(gameObject);
    }

}
