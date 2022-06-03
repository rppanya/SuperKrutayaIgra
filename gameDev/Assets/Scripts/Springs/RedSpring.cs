using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSpring : MonoBehaviour
{
    BoxCollider2D cldr;
    public static RedSpring Instance { get; set; }

    private void Awake()
    {
        Instance = this;
        cldr = GetComponent<BoxCollider2D>();
    }


    public void turnCollider(bool condition)
    {
        cldr.enabled = condition;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.SpringJump();
        }
    }
}
