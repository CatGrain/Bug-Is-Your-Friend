using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class ForwardMover : MonoBehaviour
{
    public Rigidbody2D rigid;
   
    public void Move(float Speed)
    {
        Vector2 moveDirecetion = new Vector2(Speed , rigid.velocity.y);
        rigid.velocity = moveDirecetion;
    }
}
