using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionBetweenScenes : MonoBehaviour
{
    public int id;
    public void PressButton()
    {
        SceneManager.LoadScene(id);
        Time.timeScale = 1f;
    }
}
