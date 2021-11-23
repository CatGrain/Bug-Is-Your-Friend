using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveCubeGameManager : MonoBehaviour
{
    public GameObject gameObject;

    public static MoveCubeGameManager events;
    private void Awake()
    {
        events = this;
    }

    public event UnityAction OnGameOver;
    public void PLayerIStDeath()
    {
        if(OnGameOver != null)
            OnGameOver();
    }

    private void Start()
    {
        OnGameOver += GameOver;
    }


    public void StoppObstacle()
    {
        ObstacleEvents.events.StoppObstcaleMove();
    }

    public void StartObstacle()
    {
        ObstacleEvents.events.StartObstcaleMove();
    }

    public void GameOver()
    {       
        MoveCubeCharakterController.events.StoppPlayer();       
    }
}
