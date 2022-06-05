using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowMove : Entity
{
    private float speed = 5f;
    private Vector3 dir;
    BoxCollider2D cldr;


    public Transform wallCheckPointL, wallCheckPointR;
    public LayerMask whatIsGround;


    public static YellowMove Instance { get; set; }

    private void Awake()
    {
        Instance = this;
        cldr = GetComponent<BoxCollider2D>();
    }


    public void turnCollider(bool condition)
    {
        cldr.enabled = condition;
    }


    private void Start()
    {
        dir = transform.right;
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
        }
    }
    private void Move()
    {
        if (Physics2D.OverlapCircle(wallCheckPointL.position, .1f, whatIsGround) || Physics2D.OverlapCircle(wallCheckPointR.position, .1f, whatIsGround))
        {
            dir *= -1f;
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    }
}
