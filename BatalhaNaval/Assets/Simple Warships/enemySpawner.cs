using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    //Velocidade de spawn
    private float spawnSpeed = 10f;
    //Velocidade de spawn que aumentara a acada spawn
    private float spawnSpeedDecrease = 10f;
    //Velocidade minima de spawn de inimigos
    private float minimumSpawnSpeed = 2f;
    //Posição do inimigo spawnado
    private float instanceXPosition;
    private float instanceZPosition;
    private float randomShip;

    //lista de navios inimigos
    public GameObject[] ships;

    //Chamado a cada frame
    private void Update()
    {
        //Diminuindo o contador do spawn pra poder invocar inimigos
        spawnSpeed -= Time.deltaTime;

        //Spawnando inimigos 
        if(spawnSpeed <= 0)
        {
            spawnEnemy();
            spawnSpeed = spawnSpeedDecrease;
        }
    }

    //Função de spawn de inimigos
    public void spawnEnemy()
    {
        //Só permite que a velocidade de spawn diminua se ela não tiver alcançado a velocidade minima de spawn
        if(spawnSpeedDecrease > minimumSpawnSpeed)
        {
            spawnSpeedDecrease -= 0.4f;
        }
        //Posições aleatorias do navio
        instanceXPosition = Random.RandomRange(-400f,400f);
        instanceZPosition = Random.RandomRange(-400f, 400f);

        //float que determina a chance de cada navio ser spawnado
        randomShip = Random.value;

        //Instanciando um navio diferente dependendo do valor aleatorio que foi tirado anteriormente
        if(randomShip <= 0.5f)
        {
            Instantiate(ships[0],new Vector3(transform.position.x + instanceXPosition,transform.position.y + 5f,transform.position.z + instanceZPosition), transform.rotation);
        }
        else if (randomShip <= 0.75f)
        {
            Instantiate(ships[1], new Vector3(transform.position.x + instanceXPosition, transform.position.y, transform.position.z + instanceZPosition), transform.rotation);
        }
        else if(randomShip <= 0.87f)
        {
            Instantiate(ships[2], new Vector3(transform.position.x + instanceXPosition, transform.position.y, transform.position.z + instanceZPosition), transform.rotation);
        }
        else if(randomShip <= 0.95)
        {
            Instantiate(ships[3], new Vector3(transform.position.x + instanceXPosition, transform.position.y, transform.position.z + instanceZPosition), transform.rotation);
        }
        else
        {
            Instantiate(ships[4], new Vector3(transform.position.x + instanceXPosition, transform.position.y, transform.position.z + instanceZPosition), transform.rotation);
        }

    }
}
