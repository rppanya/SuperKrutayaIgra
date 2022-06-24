using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.UI;
using TMPro;

public class TransitionTrigger : MonoBehaviour
{
    public int id;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(id);
        Time.timeScale = 1f;
    }
}
