using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    public Text infoText;


    private void Start()
    {
        GameEvents.current.startInfoPanel += StartInfoPanel;
    }

    void StartInfoPanel(string info)
    {
        ChangeText(info);
        GameEvents.current.StartInfoPanelAni();
    }



    void ChangeText(string changeText)
    {
        infoText.text = changeText;
    }


   

}
