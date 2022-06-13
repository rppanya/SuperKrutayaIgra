using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkTriggered : MonoBehaviour
{
    public GameObject TalkPaper;

    private void OnTriggerEnter2D(Collider2D collision)

    {
        TalkPaper.SetActive(true);
        
    }
}
