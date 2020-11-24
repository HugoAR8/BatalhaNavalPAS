using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Objeto player pra poder pegar a posição dele
    GameObject player;

    //Distância entre o inimigo e o player;
    private float dist;

    //Distância de visão do inimigo(ele só vai se mover se o player estiver dentro do limite)
    public float visionDist = 400f;

    //Velocidade de rotação do navio inimigo
    private float rotateSpeed = 1000;

    //Range de ataque do navio inimigo
    private float attackRange ;

    //Vetor de movimento do navio inimigo
    Vector3 Movement;

    //Direção do navio( relativo a posição do player)
    Vector3 Direction;

    //Componente que cuida das fisicas do jogo na unity
    public Rigidbody rb;

    //Script do navio do inimigo
    private Ship ship;

    //velocidade de ataque do inimigo
    private float attackSpeed = 2f;
    
    //Altura dos canhões do navio inimigo
    float randomCount = 75f;


    //Angulo que os canhões vão rotacionar
    private float rotationAngle;

    //booleana que checa se o navio inimigo está se movendo
    private bool isMoving = false;

    //booleana que checa se o player esta dentro do range de ataque do navio inimigo
    private bool onRange = false;

    //Chamado ao inicio de cada cena 
    private void Start()
    {
        //Procurando o script "Ship" dentro do inimigo
        ship = this.GetComponent<Ship>();

        //Procurando o objeto player na cena
        player = GameObject.Find("Player");

        //Setando o range de ataque pra ser a metade do range de visão do inimigo
        attackRange = visionDist / 2;
    }

    private void Update()
    {
        //Setando a distancia entre o inimigo e o player
        dist = Vector3.Distance(player.transform.position, transform.position);
        //Setando a direção do player em relação a posição do inimigo
        Direction = (player.transform.position - transform.position).normalized;
        //movimento = direção, para que o inimigo se mova na direção que o player se encontra
        Movement = Direction;
        //Rotação do barco inimigo
        var rotationAux = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationAux, rotateSpeed * Time.deltaTime);

        //Variavel de rotação dos canhões do barco inimigo
        var cannonRotationAux = Quaternion.LookRotation(new Vector3(player.transform.position.x, player.transform.position.y + randomCount, player.transform.position.z) - transform.position);

        //Rodando cada canhão inimigo
        for (int i =0; i < ship.getCannonsQtd(); i ++)
        {
            ship.cannons[i].transform.rotation = Quaternion.RotateTowards(ship.cannons[i].transform.rotation, cannonRotationAux, rotateSpeed * Time.deltaTime);
        }
        

        //Caso a distancia entre o inimigo e o player seja maior que o range de ataque
        if (dist > attackRange)
        {
            //Vai se mover em direção ao player
            Movement = Direction;
            onRange = false;
        }
        //Caso contrario
        else
        {
            //Diminuindo o contador de attackSpeed pra poder atacar a cada 2 segundos
            attackSpeed -= Time.deltaTime;
            //Atacando e resetando o attackSpeed para poder realizar o proximo ataque
            if (attackSpeed <= 0)
            {
                //Função de ataque
                ship.Attack();
                //Rotação dos canhões
                randomCount = Random.Range(40f, 160f);
                //Velocidade de ataque
                attackSpeed = 2;
            }
            //Setando o movimento do barco pra falso
            isMoving = false;
            //Setando a booleana de range do barco pra verdadeiro
            onRange = true;
            //mantendo o movimento da embarcação em 0 enquanto ela atira
            Movement.x = 0;
            Movement.y = 0;
            Movement.z = 0;
        }
    }

    //Chamado após o Update(usado para funções que exijam uso de fisica, pois assim o lag no jogo não dependera tanto da capacidade do computador do player)
    private void FixedUpdate()
    {
        //Movendo o inimigo
        move(Movement);
    }

    //Função de movimento
    private void move(Vector3 direction)
    {
        //Só se move se o player estiver no campo de visão e fora do range de tiro
        if (onRange == false && dist < visionDist)
        {
            isMoving = true;
            rb.MovePosition(transform.position + (direction * ship.speed * Time.deltaTime));
        }
    }
}
