using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string curShip;
    public bool boughtFrigate;
    public bool boughtCruiser;
    public bool boughtDestroyer;
    public bool boughtBatleship;
    public int coins;

    public PlayerData()
    {
        curShip = gameControl.curShip;
        boughtFrigate = gameControl.boughtFrigate;
        boughtCruiser = gameControl.boughtCruiser;
        boughtDestroyer = gameControl.boughtDestroyer;
        boughtBatleship = gameControl.boughtBatleship;
        coins = gameControl.coins;
    }
}
