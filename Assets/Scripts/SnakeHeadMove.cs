using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SnakeHeadMove : MonoBehaviour
{
    public TextMeshPro PointsText;
    public int Length = 1;
    public float MoveSpeed;
    private Rigidbody _rb;
    private SnakeTail componentSnakeTail;
    public BreakBarrier CubeHealth;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        componentSnakeTail = GetComponent<SnakeTail>();
        Length = componentSnakeTail.snakeCircles.Count+1;
        PointsText.SetText(Length.ToString());
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Length < 8)
            {
                componentSnakeTail.AddCircle();
            }
            Length++;
            PointsText.SetText(Length.ToString());
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            componentSnakeTail.RemoveCircle();
            Length--;
            PointsText.SetText(Length.ToString());
        }
        
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

    IEnumerator CircleRemove()
    {
        while (CubeHealth.CurrentHealth > 1)
        {
            MovementLogic(0f);
            if (componentSnakeTail.snakeCircles.Count > 0 && componentSnakeTail.positions.Count > 0)
            {
                Length--;
                PointsText.SetText(Length.ToString());
                componentSnakeTail.RemoveCircle();
                
            }
            yield return new WaitForSeconds(0.2f);
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Barrier")
        {
            StartCoroutine(CircleRemove());
        }
       
    }
  
    

}