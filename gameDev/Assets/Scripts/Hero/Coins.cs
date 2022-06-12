using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Coins : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("coin"))
        {
            Destroy(col.gameObject);
            scoreText.text = (int.Parse(scoreText.text) + 1).ToString();
        }
    }
}
