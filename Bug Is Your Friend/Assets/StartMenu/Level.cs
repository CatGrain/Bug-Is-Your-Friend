using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public BoolVariable LevelInfo;
    public GameObject level;

    private void Start()
    {
        if(!LevelDone())
        {
            Lock();
        }
    }

    bool LevelDone()
    {
        if (LevelInfo != null)
            return LevelInfo.runtimeValue;

        return false;
    }

    void Lock()
    {
        level.SetActive(false);
    }
     
}
