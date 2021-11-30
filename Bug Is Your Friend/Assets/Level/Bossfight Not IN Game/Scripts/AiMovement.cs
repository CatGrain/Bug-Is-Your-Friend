using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{
    public float MovementSpeed;
    public Transform player;
    public Vector2 restrictedArea;
    public float offsetToPlayer;

    public void Move()
    {
        Vector2 moveDirection;
        moveDirection = ClaculateNewMovePosition();
        Debug.Log(moveDirection);
        moveDirection = new Vector2(moveDirection.x,transform.position.y);
        Vector2 curentDistance = Vector2.MoveTowards(transform.position,moveDirection,MovementSpeed * Time.deltaTime);  
        transform.position = curentDistance;
    }


    Vector2 ClaculateNewMovePosition()
    {
        Vector2 newPosition = new Vector2(player.position.x, 0);

        Debug.Log("Neue Position:" + newPosition);

        if (newPosition.x < restrictedArea.x)
        {
            newPosition.x = restrictedArea.x;
        }

        if (newPosition.x > restrictedArea.y)
        {
            newPosition.x = restrictedArea.y;
          
        }
        Debug.Log("Neue Position:" + newPosition);


        newPosition = newPosition + new Vector2(offsetToPlayer,0);
        Debug.Log("Neue Position:" + newPosition);

        return newPosition;
    }

}
