using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    private void Update()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }
    public void PressButton()
    {
        Application.Quit();

    }
}
