using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BubbleInteract : MonoBehaviour
{
    public int BubbleHealth;
    public TextMeshPro Text;


    public void Start()
    {
        Text.text = BubbleHealth.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.BubbleInteract = this;
        }
    }

    public void BubbleDestroy()
    {
        Destroy(gameObject);
    }
   
}
