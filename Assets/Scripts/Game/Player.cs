using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Game Game;
    public Rigidbody Rigidbody;
    public BreakBarrier BreakBarrier;
    public TextMeshPro PointsText;
    public BubbleInteract BubbleInteract;
    public int PlayerHealth;
    public int Length;
    public int X = 4;


    private SnakeTail componentSnakeTail;


    void Start()
    {
        PlayerHealth = 1;
        componentSnakeTail = GetComponent<SnakeTail>();
        Length = componentSnakeTail.positions.Count;
        PointsText.SetText(PlayerHealth.ToString());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Length < 8)
            {
                componentSnakeTail.AddCircle();
            }
            PlayerHealth++;
            Length++;
            PointsText.SetText(PlayerHealth.ToString());
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            componentSnakeTail.RemoveCircle();
            Length--;
            PlayerHealth--;
            PointsText.SetText(PlayerHealth.ToString());
        }
    }

    IEnumerator CircleRemove()
    {
       int cubeHealth = BreakBarrier.CurrentHealth;
        while (cubeHealth > 0)
        {
            if (PlayerHealth>0)
            {
                PlayerHealth--;
                Length--;
                cubeHealth--;
                PointsText.SetText(PlayerHealth.ToString());
                if (Length > 0)
                {
                componentSnakeTail.RemoveCircle();
                }
            }
            if (PlayerHealth == 0)
            {
                Die();
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
    IEnumerator PickUpTheBubble()
    {
        while (X > 0)
        {
            componentSnakeTail.AddCircle();
            X--;
            Length++;
            PlayerHealth++;
            
            PointsText.SetText(Length.ToString());

        }
        yield return new WaitForSeconds(0.1f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Barrier")
        {
            StartCoroutine(CircleRemove());
        }
        if (other.tag == "Bubble")
        {
            BubbleInteract.BubbleDestroy();
            StartCoroutine(PickUpTheBubble());
        }
    }

    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other.collider.tag == "Barrier")
    //    {
    //        StartCoroutine(CircleRemove());
    //    }

    //}
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
