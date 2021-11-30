using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlocker : MonoBehaviour
{
    public BoolVariable levelInfo;
    private void Start()
    {
        if (!levelInfo.runtimeValue)
            Debug.Log("UnLockLevel");
            levelInfo.runtimeValue = true;       
    }
}
