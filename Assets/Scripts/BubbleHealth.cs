using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BubbleHealth : MonoBehaviour
{
    public TextMeshPro Text;
    public int CurrentNumberOfCircles;

    private void Awake()
    {
        Text.text =CurrentNumberOfCircles.ToString();
    }

}
