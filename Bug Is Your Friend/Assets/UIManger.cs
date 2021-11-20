using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManger : MonoBehaviour
{
    public GameObject[] menüPanels;
    bool menüIsOppen = false;
    GameObject curentPanel;


    // Start is called before the first frame update
    void Start()
    {
        curentPanel = menüPanels[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseAllPanel()
    {     
        menüIsOppen = false;
        curentPanel.SetActive(false);
    }

    public void OppenPanell(int nextIndexPanel)
    {
        curentPanel.SetActive(false);
        curentPanel = menüPanels[nextIndexPanel];
        curentPanel.SetActive(true);
    }

    public void ClosePanel(int pannellIndex)
    {
        curentPanel.SetActive(false);
        Debug.Log("panell Geschlossen");
        menüIsOppen = false;    
    }
}
