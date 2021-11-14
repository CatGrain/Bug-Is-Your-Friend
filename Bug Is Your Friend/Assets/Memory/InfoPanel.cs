using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    public Text infoText;


    private void Start()
    {
        MemoryGameEvents.current.startInfoPanel += StartInfoPanel;
    }

    void StartInfoPanel(string info)
    {
        ChangeText(info);
        MemoryGameEvents.current.StartInfoPanelAni();
    }



    void ChangeText(string changeText)
    {
        infoText.text = changeText;
    }


   

}
