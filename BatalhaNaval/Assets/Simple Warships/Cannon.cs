using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe Interface dos canhões, como canhões são objetos simples apenas 1 função foi colocada

/*
 * Devido ao fato de ser uma classe tão simples ela é muito fácil de expandir caso necessário em updates
 * futuros.Devido a sua simplicidade esta classe não atende a vários contextos diferentes. */


public interface Cannon
{
    //Função de tiro
    void Shoot();
}
