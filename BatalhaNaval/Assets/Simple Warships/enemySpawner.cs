using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    private float spawnSpeed = 10f;
    private float spawnSpeedDecrease = 10f;
    private float minimumSpawnSpeed = 2f;
    private float instanceXPosition;
    private float instanceZPosition;
    private float randomShip;

    public GameObject[] ships;


    private void Update()
    {
        spawnSpeed -= Time.deltaTime;
        if(spawnSpeed <= 0)
        {
            spawnEnemy();
            spawnSpeed = spawnSpeedDecrease;
        }
    }

    public void spawnEnemy()
    {
        if(spawnSpeedDecrease > minimumSpawnSpeed)
        {
            spawnSpeedDecrease -= 0.4f;
        }
        instanceXPosition = Random.RandomRange(-400f,400f);
        instanceZPosition = Random.RandomRange(-400f, 400f);
        randomShip = Random.value;
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
