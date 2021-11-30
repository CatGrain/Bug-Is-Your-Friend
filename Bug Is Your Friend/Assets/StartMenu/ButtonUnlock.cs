using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUnlock : MonoBehaviour
{
    public BoolVariable[] Level;
    public GameObject locked;

    private void Awake()
    {
        if (!LevelDone())
        {
            Lock();
        }
    }

    bool LevelDone()
    {
        foreach (var item in Level)
        {
            if(item.runtimeValue)
                return true;
        }

        return false;
    }

    public void Lock()
    {
       locked.SetActive(false);
    }

}
