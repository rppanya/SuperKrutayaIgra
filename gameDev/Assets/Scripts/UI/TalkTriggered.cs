using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TalkTriggered : MonoBehaviour
{
    public GameObject TalkPaper;
    public AudioSource audioSourse;

    private void OnTriggerEnter2D(Collider2D collision)

    {
        TalkPaper.SetActive(true);
        audioSourse.PlayOneShot(audioSourse.clip);
        
    }
}
