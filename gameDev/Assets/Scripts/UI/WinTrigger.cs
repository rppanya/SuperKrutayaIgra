using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject WinPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        WinPanel.SetActive(true);
    }
}
