using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMover : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D rigid;
    bool move;
    Vector3 moveDirection;
    public bool test;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (test)
            Move();
    }

    void Move()
    {
        moveDirection = Vector2.right;
        move = true;
    }


    private void FixedUpdate()
    {
        if (move)
            moveDirection = moveDirection * Speed * Time.deltaTime;
            rigid.MovePosition(transform.position + moveDirection);
    }

}
