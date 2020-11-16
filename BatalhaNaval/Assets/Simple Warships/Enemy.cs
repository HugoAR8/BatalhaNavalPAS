using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    private float dist;
    public float visionDist = 400f;
    private float rotateSpeed = 1000;
    private float attackRange ;
    Vector3 Movement;
    Vector3 Direction;
    public Rigidbody rb;
    private Ship ship;
    private float attackSpeed = 2f;


    private float rotationAngle;
    private bool isMoving = false;
    private bool onRange = false;

    private void Start()
    {
        ship = this.GetComponent<Ship>();
        player = GameObject.Find("Player");
        attackRange = visionDist / 2;
    }

    private void Update()
    {
        dist = Vector3.Distance(player.transform.position, transform.position);
        Direction = (player.transform.position - transform.position).normalized;
        Movement = Direction;
        var rotationAux = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationAux, rotateSpeed * Time.deltaTime);
        var cannonRotationAux = Quaternion.LookRotation(new Vector3(player.transform.position.x, player.transform.position.y + 100, player.transform.position.z) - transform.position); 


        for (int i =0; i < ship.getCannonsQtd(); i ++)
        {
            ship.cannons[i].transform.rotation = Quaternion.RotateTowards(ship.cannons[i].transform.rotation, cannonRotationAux, rotateSpeed * Time.deltaTime);
        }


        if (dist > attackRange)
        {
            Movement = Direction;
            onRange = false;
        }
        else
        {
            attackSpeed -= Time.deltaTime;
            if (attackSpeed <= 0)
            {
                ship.Attack();
                attackSpeed = 2;
            }
            isMoving = false;
            onRange = true;
            Movement.x = 0;
            Movement.y = 0;
            Movement.z = 0;
        }
    }

    private void FixedUpdate()
    {
        move(Movement);
    }


    private void move(Vector3 direction)
    {
        if (onRange == false && dist < visionDist)
        {
            isMoving = true;
            rb.MovePosition(transform.position + (direction * ship.speed * Time.deltaTime));
        }
    }
}
