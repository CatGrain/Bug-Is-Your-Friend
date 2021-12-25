using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSettingOpener : MonoBehaviour
{
    public InputManger InputManger;
    public bool playerHasPush;


    private void Start()
    {

#if UNITY_WEBGL
        Debug.Log("Game Startet Im Web");
#else
gameObject.SetActive(false);
#endif
    }

    public void StopGame()
    {      
        InputManger.PushEsc();
    }
}
