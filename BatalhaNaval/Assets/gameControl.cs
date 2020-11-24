using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/* Aqui a gente tem uma classe importantissima para o andamento do jogo, pois ela mantém os dados mais
 * importantes do player, e mesmo assim ela continua super simples
 * */

public class gameControl : MonoBehaviour
{
    //Dados importantes do jogo

    //Navio atual do player
    public static string curShip = "Corvette";

    //Camera do jogo
    public CinemachineFreeLook cameraControl;

    //quantidade de moedas
    public static int coins = 0;

    //Booleanas que checam qual navio ele comprou
    public static bool boughtFrigate = false;
    public static bool boughtCruiser = false;
    public static bool boughtDestroyer = false;
    public static bool boughtBatleship = false;


}
