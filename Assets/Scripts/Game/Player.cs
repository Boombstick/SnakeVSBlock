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
    public CurrentCube CurrentCube;
    public ParticleSystem PlayerParticle;
    public GameObject HeadSnake;
    public GameObject Text;
    public int PlayerHealth;
    public int Length;
    public int X = 4;

    public int _score;

    private AudioSource _audio;
    private SnakeTail componentSnakeTail;

   

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        PlayerHealth = 1;
        componentSnakeTail = GetComponent<SnakeTail>();
        Length = componentSnakeTail.positions.Count;
        PointsText.SetText(PlayerHealth.ToString());
        _score = PlayerPrefs.GetInt("Score");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            componentSnakeTail.AddCircle();
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
        int cubeHealth = CurrentCube.GetComponent<BreakBarrier>().CurrentHealth;
        while (cubeHealth > 0)
        {
            if (PlayerHealth>0)
            {
                cubeHealth--;
                PlayerHealth--;
                Length--;
                _score++;
                PointsText.SetText(PlayerHealth.ToString());
                PlayerPrefs.SetInt("Score", _score);
                if (Length > 0) componentSnakeTail.RemoveCircle();
                _audio.Play();  
            }
            if (PlayerHealth == 0)
            {
                Die();
                break;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
    IEnumerator PickUpTheBubble()
    {
        while (BubbleInteract.BubbleHealth > 0)
        {
            componentSnakeTail.AddCircle();
            BubbleInteract.BubbleHealth--;
            Length++;
            PlayerHealth++;
            
            PointsText.SetText(Length.ToString());

        }
        yield return new WaitForSeconds(0.1f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BreakBarrier cube))
        {
            cube.Player = this;
        }
        if (other.tag == "Barrier")
        {
            StartCoroutine(CircleRemove());
        }
        if (other.tag == "Bubble")
        {
            StartCoroutine(PickUpTheBubble());
            BubbleInteract.BubbleDestroy();
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Barrier")
        {
            StopAllCoroutines();
        }
    }
    public void ReachFinish()
    {
        Rigidbody.velocity = Vector3.zero;
        Game.OnPlayerReachedFinish();
    }

    private void ParticleStop()
    {
        PlayerParticle.Stop();
    }
    public void Die()
    {
        PlayerParticle.Play();
        Text.SetActive(false);
        HeadSnake.GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        Rigidbody.velocity = Vector3.zero;
        Invoke("ParticleStop", 1f); 
        Game.OnPlayerDied();
    }
    
}
