using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueLaser : MonoBehaviour
{
    EdgeCollider2D cldr;
    public static BlueLaser Instance { get; set; }

    private void Awake()
    {
        Instance = this;
        cldr = GetComponent<EdgeCollider2D>();
    }


    public void turnCollider(bool condition)
    {
        cldr.enabled = condition;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
        }
    }
}
