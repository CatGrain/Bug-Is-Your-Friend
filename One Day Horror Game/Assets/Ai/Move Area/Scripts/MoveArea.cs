using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArea : MonoBehaviour
{
    public float areaSize;
    public Transform start;
    public Transform end;

    public bool debug;
    public GameObject debugObject;

    // Start is called before the first frame update
    void Start()
    {
        SetSize(areaSize);
    }

    public Vector3 GetRandomPosition(float yPosition)
    {
        float randomX = Random.Range(end.position.x, start.position.x);
        float randomY = Random.Range(end.position.z, start.position.z);

        return new Vector3(randomX, yPosition, randomY);
    }

    void SetSize(float size)
    {
        Vector3 startPosition = new Vector3(areaSize,0,areaSize);
        Vector3 endPosition = new Vector3(-areaSize, 0, -areaSize);

        start.position = startPosition;
        end.position = endPosition; 
    }


}
