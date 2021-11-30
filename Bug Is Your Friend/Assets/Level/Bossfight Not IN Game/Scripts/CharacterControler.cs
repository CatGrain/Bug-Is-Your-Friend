using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    Vector3 m_Velocity = Vector3.zero;

    public void Move(float speed,float moveDirection)
    {
        moveDirection = moveDirection * speed;
        rigidbody.velocity = new Vector2(moveDirection, rigidbody.velocity.y);
    }

    public void Jump(float jumpForce)
    {
        rigidbody.velocity = Vector2.up * jumpForce;
    }
  
}
