using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleEvents : MonoBehaviour
{
    public static ObstacleEvents events;

    private void Awake()
    {
        events = this;
    }

    public event UnityAction OnStoppMove;
    public void StoppObstcaleMove()
    {
        if(OnStoppMove != null)
            OnStoppMove.Invoke();
    }
    
    public event UnityAction OnStartMove;
    public void StartObstcaleMove()
    {
        if (OnStartMove != null)
            OnStartMove.Invoke();
    }


}
