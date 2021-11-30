using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiControler : MonoBehaviour
{
    public bool atack;
    public Transform player;
    public Transform transform;
    public GameObject test;
    

    private void Update()
    {
        if(atack)
        {
            Atack();
        }


    }

    Vector2 ClaculatePlayerDirection()
    {
        return transform.position - player.position;
    }

    void Atack()
    {
        Vector2 playerDirection = ClaculatePlayerDirection();
        test.transform.position   = playerDirection.normalized;
    }

}
