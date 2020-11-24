using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinQTDMenu : MonoBehaviour
{
    private void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = gameControl.coins.ToString();
    }
}
