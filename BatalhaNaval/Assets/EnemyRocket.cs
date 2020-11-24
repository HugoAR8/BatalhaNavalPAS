using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocket : rocket
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
        damage = 40;
        rb.velocity = transform.forward * speed; // Faz com que o tiro se mova.
    }

    //chamado a cada frame
    void Update()
    {
        //Destruindo o tiro após um tempo dentro do game pro jogo pesar menos
        life -= Time.deltaTime;
        if (life <= 0)
        {
            Destroy(gameObject);
        }

        //Gravidade do tiro 
        velocity.y += gravity * Time.deltaTime;
        rb.MovePosition(transform.position + velocity);

    }

    //Função é chamada ao colidir com outro objeto
    private void OnTriggerStay(Collider other)
    {

        //Caso tenha colidido com um objeto que contém o script ship e a tag é "Player"
        Ship ship = other.GetComponent<Ship>();
        if (ship != null && ship.tag == "Player")
        {
            //Causar dano ao player
            ship.takeDamage(ship,this);
            //Destruir tiro
            Destroy(gameObject);
        }

    }
}
