using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColor : MonoBehaviour
{
    public Material CubeMaterial0;
    public Material CubeMaterial25;
    public Material CubeMaterial50;
    public Material CubeMaterial75;
    public Material CubeMaterial100;
    private BreakBarrier breakBarrier;



    private void Awake()
    {
        breakBarrier = GetComponent<BreakBarrier>();
    }
    private void Start()
    {

        if (breakBarrier.CurrentHealth <= 3) gameObject.GetComponent<Renderer>().material = CubeMaterial0;
        else if (breakBarrier.CurrentHealth > 3 && breakBarrier.CurrentHealth <= 6) gameObject.GetComponent<Renderer>().material = CubeMaterial25;
        else if (breakBarrier.CurrentHealth > 6 && breakBarrier.CurrentHealth <= 9) gameObject.GetComponent<Renderer>().material = CubeMaterial50;
        else if (breakBarrier.CurrentHealth > 9 && breakBarrier.CurrentHealth <= 12) gameObject.GetComponent<Renderer>().material = CubeMaterial75;
        else if (breakBarrier.CurrentHealth > 12) gameObject.GetComponent<Renderer>().material = CubeMaterial100;
    }
}
