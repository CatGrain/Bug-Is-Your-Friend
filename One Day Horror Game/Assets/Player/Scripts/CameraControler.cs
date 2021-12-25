using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public float ySentivity;
    public float xSentivity;
    float XAxis;
    float YAxis;
    public Transform player;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        ControlCamera();      
    }


    void ControlCamera()
    {
        float mouseY = Input.GetAxis("Mouse Y") * ySentivity * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * xSentivity * Time.deltaTime;

        XAxis += mouseY;
        YAxis += mouseX;

        XAxis = Mathf.Clamp(XAxis, -90, 90);       
      
       
        if (player != null)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(XAxis,0, 0));
            MovePlayer();
        }
        else
        {
            transform.localRotation = Quaternion.Euler(new Vector3(XAxis, YAxis, 0));
            return;
        }
    }

    void MovePlayer()
    {
        player.transform.rotation = Quaternion.Euler(new Vector3(0, YAxis, 0));
    }
}
