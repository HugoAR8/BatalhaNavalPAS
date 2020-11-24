using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frigate : Ship
{
    //Chamado ao inicio de cada cena 
    private void Start()
    {
        //Definindo a vida do navio
        life = 350;
    }
    //Chamado a cada frame
    private void Update()
    {
        //Caso a vida do navio chegue a menos de 0
        if (life <= 0)
        {
            //Destruir navio
            Destroyed();
        }
    }

    //Função de atirar do navio
    public override void Attack()
    {
        //Roda um for pela lista de canhões do navio 
        for (int i = 0; i < getCannonsQtd(); i++)
        {
            //Puxando a função de atirar de cada canhão da lista
            cannons[i].GetComponent<Cannon>().Shoot();
        }

    }
}
