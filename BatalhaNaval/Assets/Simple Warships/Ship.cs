using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Essa classe representa o comportamento que todos os navios do jogo terão, dando uma responsabilidade 
   unica a mesma.
   Devido a sua simplicidade esta classe não atende a vários contextos diferentes. 
   Polimorfismo foi utilizado para atribuir a responsabilidade das diferentes classes e tipos de navios a 
   essa classe especifica.
 */
public abstract class Ship : MonoBehaviour
{
    //Vida do navio
    protected int life = 0;
    protected int maxLife;
    
    //booleana que checa se o navio foi destruido
    public bool isDead = false;

    //Quantidade de moedas que o navio da
    public int coinDrops = 0;

    //Velocidade do navio
    public float speed;
    protected float damagedSpeed;


    //Lista de canhões do navio
    public GameObject[] cannons;

    //Chamado no inicio da cena
    void Start()
    {
        
        life = maxLife;
        damagedSpeed = speed / 2;
    }

    // Chamado a cada frame
    void Update()
    {
        //Caso a vida seja menor que 0 destruir navio
        if(life <= 0 )
        {
            isDead = true;
            Destroyed();
        }
    }

    //Função abstrata de ataque
    public abstract void Attack();


    //Função de pegar o tamanho da lista de canhões do navio
    public int getCannonsQtd(){
        return cannons.Length;
    }

    //função de receber dano
    public virtual void takeDamage(Ship ship, rocket hitRocket)
    {
        ship.life = ship - hitRocket;
    }

    //Sobrecarga de operadores usada para a função de tomar dano do navio
    public static int operator - (Ship ship, rocket hitRocket)
    {
        int resultado;
        resultado = ship.life - hitRocket.damage;
        return resultado;
    }

    //Função pra quando o navio é destruido
    public virtual void Destroyed()
    {
        gameControl.coins += coinDrops;
        Destroy(gameObject);
    }

}
