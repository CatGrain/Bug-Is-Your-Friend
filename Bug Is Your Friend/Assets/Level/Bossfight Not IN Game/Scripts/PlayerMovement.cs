using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpHigh;
    public CharacterControler characterControler;
    Vector3 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            characterControler.Jump(jumpHigh);
            Debug.Log("Jump");
        }

        characterControler.Move(speed, Input.GetAxis("Horizontal"));


       
    }




}
