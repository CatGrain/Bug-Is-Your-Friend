using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveCubeCharakterController : MonoBehaviour
{
    public float Speed;

    ForwardMover forwardMover;    
    bool move = true;

    //Events 
    public static MoveCubeCharakterController events;
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
  

    // Start is called before the first frame update
    void Start()
    {
        forwardMover = GetComponent<ForwardMover>();
        OnStoppPlayer += StoppMove;
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
