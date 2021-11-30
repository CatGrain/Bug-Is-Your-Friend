using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManger : MonoBehaviour
{
    public GameObject[] menüPanels;
    bool menüIsOppen = false;
    GameObject curentPanel;
    public GameObject[] ActivPanels;

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
        curentPanel = menüPanels[nextIndexPanel];
        curentPanel.SetActive(true);
    }

    public void ChangePannell(int nextIndexPanel)
    {
        curentPanel.SetActive(false);
        curentPanel = menüPanels[nextIndexPanel];
        curentPanel.SetActive(true);
    }

    public void ClosetPanel(int pannellIndex)
    {
        curentPanel.SetActive(false);
        Debug.Log("panell Geschlossen");
        menüIsOppen = false;    
    }

    public void CloseCurentPanel()
    {
        if (curentPanel != null)
            curentPanel?.SetActive(false);  
    }

    public bool IsPannellOppen(int pannellIndex)
    {
        if(menüPanels[pannellIndex] == null)
            return false;

        return menüPanels[pannellIndex].activeInHierarchy;
    }
}
