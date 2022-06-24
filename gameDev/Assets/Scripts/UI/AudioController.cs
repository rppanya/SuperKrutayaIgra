using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    void Start()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            audioSource.volume = 1;
            AudioListener.volume = 1;
        }
    }

    private void Update()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
        audioSource.volume = PlayerPrefs.GetFloat("volume");
    }
}
