using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WinnerInfoDispaly : MonoBehaviour
{
    public Text winnerNameText;
    public GameObject winnerImage;


    public void StartInfoDispaly(string winnerName)
    {        
        winnerNameText.text = winnerName;
    }
}
