using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBarrier : MonoBehaviour
{ 
    public int CurrentHealth;



    IEnumerator HealthController()
    {
        while (CurrentHealth >= 0)
        {
            CurrentHealth--;
            if (CurrentHealth == 0)
            {
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(0.3f);
        }
       
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
