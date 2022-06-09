using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLaserT : MonoBehaviour
{
    private float timer = 2f;
    public float frequency;
    private bool con;
    private BoxCollider2D cldr;
    private SpriteRenderer sprite;

    public static RedLaserT Instance { get; set; }

    public void turnCollider(bool condition)
    {
        cldr.enabled = condition;
        con = condition;
    }

    private void Awake()
    {
        cldr = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        cldr.enabled = false;
        sprite.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Hero.Instance.gameObject == collision.gameObject)
        {
            Hero.Instance.GetDamage();
        }
    }

    private void Update()
    {
        if (timer <= frequency)
        {
            if (con)
            {
                cldr.enabled = true;
            }
            sprite.enabled = true;
        }
        else
        {
            cldr.enabled = false;
            sprite.enabled = false;
        }

        if (timer <= 0)
        {
            timer = frequency * 2;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
