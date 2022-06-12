using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public float volume = 0;
    public int quality = 0;
    public bool isFullscreen = false;
    public AudioMixer audioMixer;

    public void ChangeVolume(float val)
    {
        volume = val;
    }

    public void ChangeFullScreenMode(bool val)
    {
        isFullscreen = val;
    }

    public void ChangeQuality(int index)
    {
        quality = index;
    }

    public void SaveSettings()
    {
        audioMixer.SetFloat("MasterVolume", volume);
        QualitySettings.SetQualityLevel(quality);
        Screen.fullScreen = isFullscreen;
    }
}
