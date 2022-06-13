using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackFall : MonoBehaviour
{
    BoxCollider2D bc;
    CircleCollider2D cc;
    Rigidbody2D rb;

    private float gravityStore;
    public static BlackFall Instance { get; set; }

    private void Awake()
    {
        Instance = this;
        bc = GetComponent<BoxCollider2D>();
        cc = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        gravityStore = rb.gravityScale;
        rb.gravityScale = 0f;
    }

    public void turnCollider(bool condition)
    {
        cc.enabled = condition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            rb.gravityScale = gravityStore;
        }
    }
}
