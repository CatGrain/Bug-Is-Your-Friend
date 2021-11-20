using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InputManger : MonoBehaviour
{     
    public event UnityAction OnPlayerPushEsc;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {           
            OnPlayerPushEsc?.Invoke();
        }     
    }
}
