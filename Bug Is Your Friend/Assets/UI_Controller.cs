using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_Controller : MonoBehaviour
{
    public UIManger uIManger;
    public InputManger inputManger;
    bool uiOppen;

    //Events 
    public UnityEvent OnOppenMen�;
    public UnityEvent OnCloseMen�;



    private void Start()
    {
        inputManger.OnPlayerPushEsc += HandelPalyerInput;
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

    public void ChangePanell(int index)
    {
        if (uIManger != null)
            uIManger.OppenPanell(index);
    }

    public void CloseUi()
    {
        if (uIManger != null)
            uIManger.CloseAllPanel();
        OnCloseMen�?.Invoke();
    }
}
