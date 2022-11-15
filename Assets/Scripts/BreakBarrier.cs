using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBarrier : MonoBehaviour
{
    public int MinHealth;
    public int MaxHealth;
    public int CurrentHealth;

    private void Awake()
    {
        CurrentHealth = MinHealth;
    }

    IEnumerator HealthController()
    {
        while (MinHealth > 0)
        {
            MinHealth--;
            CurrentHealth = MinHealth+1;
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
