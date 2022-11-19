using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public bool MusicOn;
    [Min(0)]
    public float Volume;
    private AudioSource _audio;
    public float VolumeScale;
    public GameObject AudioManager;

    public int AudioCount;

    private void Awake()
    {
        AudioCount = GameObject.FindGameObjectsWithTag("AudioManager").Length;
    }
    public void Start()
    {
        if (AudioCount == 1) MusicOn = true;
        else Destroy(AudioManager);
        
        _audio = GetComponent<AudioSource>();
        Object.DontDestroyOnLoad(AudioManager);
    }

    void Update()
    {
        if (MusicOn)
            _audio.mute = false;
        else
            _audio.mute = true;
        AudioListener.volume = Volume;
    }
}
