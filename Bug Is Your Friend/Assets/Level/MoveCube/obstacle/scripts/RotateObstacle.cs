using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacle : MonoBehaviour
{
    public float speed;
    public float rotationOnFrame; 
    Vector3 rotation;


    public void Rotate()
    {
        rotation =  CalculateRotation();       
        transform.Rotate(rotation);
    }

    Vector3 CalculateRotation()
    {
        return new Vector3(0,0,speed * rotationOnFrame * Time.deltaTime);
    }
}
