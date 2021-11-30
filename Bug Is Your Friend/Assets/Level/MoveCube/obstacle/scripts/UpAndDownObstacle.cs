using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDownObstacle : MonoBehaviour
{
    public float speed;
    public float maxHigh;

    public Vector2 OrginPosition;
    Vector2 targetPosition;

    private void Start()
    {
        OrginPosition = transform.position;
        targetPosition = CalclualteTargetPosition();
    }


    public void Move()
    {
        if(IsPlayerOnTarget())
        {
            ChangeTargetPOsition();
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    bool IsPlayerOnTarget()
    {
        if((Vector2)transform.position == targetPosition)
        {
            return true;
        }

        return false;
    }

    void ChangeTargetPOsition()
    {
        if(targetPosition == OrginPosition)
        {
            targetPosition = CalclualteTargetPosition();
        }
        else
        {
            targetPosition = OrginPosition;
        }
    }

    Vector2 CalclualteTargetPosition()
    {
        return new Vector2(transform.position.x,maxHigh);
    }
}
