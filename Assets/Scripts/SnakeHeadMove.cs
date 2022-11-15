using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SnakeHeadMove : MonoBehaviour
{
    public float MoveSpeed;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        MovementLogic(MoveSpeed);
    }

    private void MovementLogic(float MoveSpeed)
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 1f);

        _rb.AddForce(movement * MoveSpeed);
        
    }

  
  
    

}