using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTalkPaper : MonoBehaviour
{
    public GameObject TalkPaper;
    public void PressButton()
    {
        TalkPaper.SetActive(false);

    }
}
