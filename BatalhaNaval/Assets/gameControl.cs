using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class gameControl : MonoBehaviour
{
    public static string curShip = "abadebis";
    public CinemachineFreeLook cameraControl;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (curShip == "Corvette")
        {
            
        }
        else if (curShip == "Frigate")
        {

        }
        else if (curShip == "Cruiser")
        {

        }
        else if (curShip == "Destroyer") 
        {

        }
        else
        {
            
        }
    }

}
