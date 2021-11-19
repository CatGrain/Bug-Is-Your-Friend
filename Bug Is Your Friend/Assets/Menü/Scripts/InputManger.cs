using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InputManger : MonoBehaviour
{
    public UnityEvent OppenMen�;
    public UnityEvent CloseMen�;
    public GameObject gameObject;
    public bool menuIsOppen = false;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !menuIsOppen)
        {
            if (OppenMen� != null)
            {
                OppenMen�.Invoke();
                menuIsOppen=true;
            }
            gameObject.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(CloseMen� != null)
            {
                CloseMen�.Invoke();
            }
            gameObject.SetActive(false);
            menuIsOppen=false;
        }

    }
}
