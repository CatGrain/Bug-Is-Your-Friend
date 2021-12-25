using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiControler : MonoBehaviour
{
    public float Speed;
    public float SeeRage;
    public float SeeDistance;
    public Vector3 seePosition;
    public MoveArea moveArea;
    Vector3 targetMovePosition;

    private void Start()
    {
        targetMovePosition = moveArea.GetRandomPosition(transform.position.y);
    }

    public void Update()
    {
        Move();

        if(SeeIfThereIsAPlayerNearby())
        {
            Debug.Log("Spieler Gesichtet");
        }
      
    }

    bool SeeIfThereIsAPlayerNearby()
    {
        RaycastHit hit;
        bool IsPlayerNearby = Physics.SphereCast(transform.position, SeeRage,transform.position + transform.forward * SeeDistance, out hit);

        if(IsPlayerNearby && hit.collider.tag == "Player")
        {
            return true;
        }
        return false;
    }


    void Move()
    {
        Vector3 curentPosition = Vector3.MoveTowards(transform.position,targetMovePosition,Speed * Time.deltaTime);
        if(targetMovePosition == curentPosition)
        {
            GetNewMovePosition();
        }
        else
        {
            transform.position = curentPosition;
        }
    }

    void GetNewMovePosition()
    {
        Vector3 newPosition = moveArea.GetRandomPosition(transform.position.y);
        transform.LookAt (newPosition);
        targetMovePosition = newPosition;
    }

    private void OnDrawGizmos()
    {       
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(targetMovePosition, 1f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + transform.forward * SeeDistance, SeeRage);
    }

    
}
