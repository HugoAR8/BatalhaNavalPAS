using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinQTDMenu : MonoBehaviour
{
    //Chamado a cada frame
    private void Update()
    {
        //Muda o texto pra quantidade de moedas que o player tem
        gameObject.GetComponent<TextMeshProUGUI>().text = gameControl.coins.ToString();
    }
}
