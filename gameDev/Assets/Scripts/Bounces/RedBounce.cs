using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBounce : MonoBehaviour
{
    Rigidbody2D rb;
    CircleCollider2D cldr;

    public Transform wallCheckPoint;
    public LayerMask whatIsGround;
    private bool cldrCon;
    public static RedBounce Instance { get; set; }

    private void Awake()
    {
        Instance = this;
        cldr = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * 25f, ForceMode2D.Impulse);
    }


    public void turnCollider(bool condition)
    {
        if (condition)
        {
            cldr.enabled = condition;
        }
        cldrCon = condition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject && cldrCon == false)
        {
            cldr.enabled = false;
        }
        if (collision.gameObject == Hero.Instance.gameObject && cldrCon == true)
        {
            cldr.enabled = true;
            Hero.Instance.GetDamage();
        }
    }

    private void Update()
    {
        if (Physics2D.OverlapCircle(wallCheckPoint.position, cldr.radius, whatIsGround))
        {
            cldr.enabled = true;
        }
    }
}
