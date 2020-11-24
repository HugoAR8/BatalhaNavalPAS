using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRocket : rocket
{
    private float speed = 500f; // velocidade do tiro.

    public Rigidbody rb; // Criando uma variavel para utilizar o rigidbody do tiro
    private float life = 4f;

    //Gravidade do tiro

    public Vector3 velocity; 
    private float gravity = -2.81f;

    // Start is called before the first frame update
    void Start()
    {
        damage = 100;
        rb.velocity = transform.forward * speed; // Faz com que o tiro se mova.
    }

    void Update()
    {
        life -= Time.deltaTime;
        if(life <= 0)
        {
            Destroy(gameObject);
        }

        velocity.y += gravity * Time.deltaTime;
        rb.MovePosition(transform.position + velocity);

    }

    private void OnTriggerStay(Collider other)
    {
        
        Ship ship = other.GetComponent<Ship>();
        if (ship != null && ship.tag == "Enemy") 
        {

            ship.takeDamage(ship,this);
            Destroy(gameObject);
        }

    }
}
