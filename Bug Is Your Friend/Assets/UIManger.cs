using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManger : MonoBehaviour
{
    public GameObject[] men�Panels;
    bool men�IsOppen = false;
    GameObject curentPanel;


    // Start is called before the first frame update
    void Start()
    {
        curentPanel = men�Panels[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseAllPanel()
    {     
        men�IsOppen = false;
        curentPanel.SetActive(false);
    }

    public void OppenPanell(int nextIndexPanel)
    {
        curentPanel.SetActive(false);
        curentPanel = men�Panels[nextIndexPanel];
        curentPanel.SetActive(true);
    }

    public void ClosePanel(int pannellIndex)
    {
        curentPanel.SetActive(false);
        Debug.Log("panell Geschlossen");
        men�IsOppen = false;    
    }
}
