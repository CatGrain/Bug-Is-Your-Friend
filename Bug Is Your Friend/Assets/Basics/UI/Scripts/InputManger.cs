using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InputManger : MonoBehaviour
{     
    //Events
    public event UnityAction OnPlayerPushEsc;
    public UnityEvent onPLayerPushAnyButton;
    public event UnityAction onBlockInput;
    public event UnityAction onUnlockInput;

    //Variablen
    bool inputLocked = false;
    bool blockAnyInput = false;

    //Event Start Metoden
    public void OnBlockInput()
    {
        if (onBlockInput != null)   
            onBlockInput();

    }
  
    public void OnUnlockInput()
    {
        if (onUnlockInput != null)
            onUnlockInput();
    }

   

    public static InputManger instance;
    private void Awake()
    {
        instance = this;
    }



    private void Start()
    {
        onBlockInput += BlockInput;
        onUnlockInput += UnlockInput;
    }

    private void Update()
    {
        
        PushPlayerEscape();
        PushPlayerAnyBuoton();
    }

    public void PushPlayerEscape()
    {
        if (!inputLocked && Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("PlayerPushEscape");
            OnPlayerPushEsc?.Invoke();
           
        }
    }

    public void PushPlayerAnyBuoton()
    {
        if(Input.anyKeyDown && !inputLocked && !Input.GetKeyDown(KeyCode.Escape) && !blockAnyInput)
        {          
            onPLayerPushAnyButton?.Invoke();
        }
    }


    void BlockInput()
    {
        Debug.Log("Block Input");
        inputLocked = true;
    }

    void UnlockInput()
    {
        Debug.Log("Unlock");
        inputLocked = false;
    }

    public void UnlockAnyInput()
    {
        blockAnyInput = false;
    }

    public void BlockAnyInput()
    {
        blockAnyInput = true;
    }
}
