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

        Cursor.lockState = CursorLockMode.Confined;
    }

    public void DeactivateCursor()
    {
        Cursor.visible = false;
    }
    public void ActivateCursor()
    {
        Cursor.visible = true;       
    }


}
