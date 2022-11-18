using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Player Player;
    public Transform Finish;
    public Slider Slider;

    private float _start;

    private void Start()
    {
        _start = Player.transform.position.z;
    }

    private void Update()
    {
        float finishZ = Finish.transform.position.z;

        float t = Mathf.InverseLerp(_start, finishZ,Player.transform.position.z);

        Slider.value = t;
    }
}

