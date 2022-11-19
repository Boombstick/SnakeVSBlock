using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SnakeHeadMove : MonoBehaviour
{
    public float Sensativity;
    public float MoveSpeed;
    public float MaxSpeed;
    private Rigidbody _rb;
    

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        MovementLogic();

        
    }


    private void MovementLogic()
    {

        Vector3 movement = new Vector3(0f, 0.0f, MoveSpeed);
        _rb.velocity = movement;
        if (Input.GetKey("a")|| Input.GetKey("d"))
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            movement = new Vector3(moveHorizontal*Sensativity, movement.y, movement.z);
            _rb.AddForce(movement);
        }
        //if (_rb.velocity.magnitude == MaxSpeed)
        //{
        //    _rb.velocity = _rb.velocity.normalized * MaxSpeed;
        //}

    }

}