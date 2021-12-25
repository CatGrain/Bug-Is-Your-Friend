using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBCharacterControler : MonoBehaviour
{
    Rigidbody rb;
    float moveSpeed;
    public float rbDrag;
    public float moveMutipler;
    Vector3 moveDirection;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    public void Move(Vector3 direction,float speed)
    {
        moveDirection = direction;
        moveSpeed = speed;
    }

    void MovePlayer()
    {       
        rb.AddForce(moveDirection.normalized * moveSpeed * moveMutipler, ForceMode.Acceleration);
    }

    void ControlDrag()
    {
        rb.drag = rbDrag; 
    }

    private void FixedUpdate()
    {
        ControlDrag();
        MovePlayer();
    }

}
