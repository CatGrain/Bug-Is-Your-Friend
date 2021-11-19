using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InputManger : MonoBehaviour
{
    public UnityEvent OppenMenü;
    public UnityEvent CloseMenü;
    public GameObject gameObject;
    public bool menuIsOppen = false;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !menuIsOppen)
        {
            if (OppenMenü != null)
            {
                OppenMenü.Invoke();
                menuIsOppen=true;
            }
            gameObject.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(CloseMenü != null)
            {
                CloseMenü.Invoke();
            }
            gameObject.SetActive(false);
            menuIsOppen=false;
        }

    }
}
