using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBarrier : MonoBehaviour
{ 
    public int CurrentHealth;



    IEnumerator HealthController()
    {
        while (CurrentHealth > 0)
        {
            CurrentHealth--;
            if (CurrentHealth == 1)
            {
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(0.2f);
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(HealthController());
 
    }
   


}
