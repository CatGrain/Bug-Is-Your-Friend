using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public delegate void ObscaleBehavior();

public class Obscale : MonoBehaviour
{
    //Container F�r die Verhaltens Metode des Obscales
    public UnityEvent obscaleBehavior;

    bool obstacleActive = true;

    //Event Instance
    public static Obscale current;

    
    private void Awake()
    {
        current = this;
    }


    private void Start()
    {
        ObstacleEvents.events.OnStartMove += StartObstacle;
        ObstacleEvents.events.OnStoppMove += StoppObstacle;       
    }


    public void Update()
    {
        //Solange Pausen Men� Nicht Ge�fnet F�re Obscale Aus
        if(obstacleActive)
        {
            obscaleBehavior.Invoke();
        }
    }

    void StoppObstacle()
    {
        obstacleActive = false;
    }

    void StartObstacle()
    {
        obstacleActive = true;
    }
}


