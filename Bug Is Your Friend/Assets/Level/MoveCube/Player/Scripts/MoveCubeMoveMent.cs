using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MoveCubeMoveMent : MonoBehaviour
{
    public float Speed;

    ForwardMover forwardMover;    
    public bool move = false;

    //Events 
    public static MoveCubeMoveMent events;
    private void Awake()
    {
        events = this;
    }

    public event UnityAction OnStoppPlayer;
    public void StoppPlayer()
    {
        if (events != null)
            events.OnStoppPlayer();
    }

    public event UnityAction OnStartPlayer;
    public void StartPlayer()
    {
        if (events != null)
            events.OnStartPlayer();
    }


    // Start is called before the first frame update
    void Start()
    {
        forwardMover = GetComponent<ForwardMover>();
        OnStoppPlayer += StoppMove;
        OnStartPlayer += StartMove;
    }

    // Update is called once per frame
    void Update()
    {
        if(move)
        {
            forwardMover.Move(Speed);
        }
    }

    void StoppMove()
    {
        move = false;
    }

    void StartMove()
    {
        move = true;
    }
}
