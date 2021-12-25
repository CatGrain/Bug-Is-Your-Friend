using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public bool deactivateCursorToStart;

    private void Start()
    {

        if(deactivateCursorToStart)
        {
            DeactivateCursor();
        }
        else
        {
            ActivateCursor();
        }

#if UNITY_WEBGL
        ActivateCursor();
#endif

        Cursor.lockState = CursorLockMode.Confined;
    }

    public void DeactivateCursor()
    {
#if UNITY_STANDALONE
        Cursor.visible = false;
#endif
    }
    public void ActivateCursor()
    {
        
        Cursor.visible = true;       
    }


}
