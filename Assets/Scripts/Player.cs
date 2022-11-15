using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Game Game;
    public Rigidbody Rigidbody;
    public BreakBarrier Cube;
    public BreakBarrier CubeHealth;
    public TextMeshPro PointsText;
    public int PlayerHealth;
    public int Length = 1;


    private SnakeTail componentSnakeTail;


    void Start()
    {
        componentSnakeTail = GetComponent<SnakeTail>();
        Length = componentSnakeTail.snakeCircles.Count + 1;
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

    IEnumerator CircleRemove()
    {
        while (CubeHealth.CurrentHealth > 1)
        {
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
    public void ReachFinish()
    {
        Game.OnPlayerReachedFinish();
        Rigidbody.velocity = Vector3.zero;
    }

    public void Die()
    {
        Game.OnPlayerDied();
        Rigidbody.velocity = Vector3.zero;
    }
}
