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
        if (_rb.velocity.magnitude >= MaxSpeed)
        {
            _rb.velocity = _rb.velocity.normalized * MaxSpeed;
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal * Sensativity*MoveSpeed, 0.0f, MoveSpeed);
      
        _rb.AddForce(movement);

       

    }

}