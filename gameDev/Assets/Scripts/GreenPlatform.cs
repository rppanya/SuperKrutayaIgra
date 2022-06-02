using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlatform : MonoBehaviour
{
    BoxCollider2D cldr;
    public static GreenPlatform Instance { get; set; }

    private void Awake()
    {
        Instance = this;
        cldr = GetComponent<BoxCollider2D>();
    }


    public void turnCollider(bool condition)
    {
        cldr.enabled = condition;
    }
}
