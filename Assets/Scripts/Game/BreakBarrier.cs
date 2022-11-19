using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBarrier : MonoBehaviour
{ 
    public int CurrentHealth;
    public ParticleSystem ParticleSystem;
    public GameObject Text;
    public Player Player;

    private AudioSource _audio;

    private void Awake()
    {
        

    }
    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }
    IEnumerator HealthController()
    {
        while (CurrentHealth >= 0)
        {
            CurrentHealth--;
            if (CurrentHealth == 0)
            {
               GetComponent<Renderer>().enabled = false;
               GetComponent<MeshCollider>().enabled = false;
               Text.SetActive(false);
               ParticleSystem.Play();
                Invoke("DestroyObject", 1f);
                _audio.Play();
            }
            if (Player.PlayerHealth==0)
            {
                break;
            }
          

            yield return new WaitForSeconds(0.3f);
        }
       
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
        StartCoroutine(HealthController());
        gameObject.GetComponent<BoxCollider>().enabled = false;

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
        StopAllCoroutines();
        gameObject.GetComponent<BoxCollider>().enabled = true;

        }
    }



}
