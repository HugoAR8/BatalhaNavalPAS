using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    protected float life = 0;
    [SerializeField] protected float maxLife;

    [SerializeField] protected float speed;
    protected float damagedSpeed;

    [SerializeField] protected int smallCannonQtd;
    [SerializeField] protected int mediumCannonQtd;
    [SerializeField] protected int bigCannonQtd;
    //Criar listas de cada tipo de canhão.




    // Start is called before the first frame update
    void Start()
    {
        life = maxLife;
        damagedSpeed = speed / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void underAttack(float damage)
    {
    }

    public virtual void Attack()
    {
    }

}
