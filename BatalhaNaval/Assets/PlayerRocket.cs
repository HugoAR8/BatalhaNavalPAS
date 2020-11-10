using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRocket : MonoBehaviour
{
    private float speed = 500f; // velocidade do tiro.
    private int damage = 20; // Dano do tiro.
    public Rigidbody rb; // Criando uma variavel para utilizar o rigidbody do tiro

    //Gravidade do tiro

    public Vector3 velocity; 
    private float gravity = -2.81f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * speed; // Faz com que o tiro se mova.
    }
    void Update()
    {
        velocity.y += gravity * Time.deltaTime;
        rb.MovePosition(transform.position + velocity);

    }
}
