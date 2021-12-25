using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    RBCharacterControler characterControler;


    // Start is called before the first frame update
    void Start()
    {
        characterControler = GetComponent<RBCharacterControler>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 moveDirection;
        moveDirection = transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal");
        characterControler.Move(moveDirection,Speed);
    }
}
