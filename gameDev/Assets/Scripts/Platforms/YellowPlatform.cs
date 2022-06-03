using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlatform : MonoBehaviour
{
    BoxCollider2D cldr;
    public static YellowPlatform Instance { get; set; }

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
