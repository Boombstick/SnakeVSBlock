using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeHealth : MonoBehaviour
{
    public TextMeshPro Text;
    public BreakBarrier BreakBarrier;

    private void Update()
    {
        Text.text = BreakBarrier.CurrentHealth.ToString();
    }


}
