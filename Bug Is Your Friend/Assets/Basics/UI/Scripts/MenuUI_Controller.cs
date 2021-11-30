using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuUI_Controller : MonoBehaviour
{
    public UIManger uIManger;
    public InputManger inputManger;

    bool uiOppen;
    bool gameOverPanelIsOppen;


    //Events 
    public UnityEvent OnOppenMen�;
    public UnityEvent OnCloseMen�;

    private void Start()
    {
        inputManger.OnPlayerPushEsc += HandelPalyerInput;
        //MoveCubeGameManager.events.OnGameOver += OppenGameOverPanel;
    }

    

    void HandelPalyerInput()
    {
        if (uiOppen)
        {
            CloseUi();
            uiOppen = false;                
        }
        else
        {           
            OppenMen�();
            uiOppen = true;            
        }
    }

    void OppenMen�()
    {
        if (uIManger != null)
            uIManger.OppenPanell(0);
        OnOppenMen�?.Invoke();
    }

    public void OppenPannell(int index)
    {
        if (uIManger != null)
            uIManger.OppenPanell(index);
    }

    public void OppenGameOverPanel()
    {
        if (uIManger != null)
            uIManger.ChangePannell(2);
        gameOverPanelIsOppen = true;
        uiOppen = false;
    }

    public void OppenGameWinnPannell()
    {
        if (uIManger != null)
            uIManger.ChangePannell(4);
        gameOverPanelIsOppen = true;
        uiOppen = false;
    }

    public void ChangePanell(int index)
    {
        if (uIManger != null)
            uIManger.ChangePannell(index);
    }

    public void CloseUi()
    {
        if (uIManger != null)
            uIManger.CloseAllPanel();
        uiOppen = false;
        OnCloseMen�?.Invoke();      
    }
}
