using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMove : Entity
{
    private float speed = 10f;
    private Vector3 dir;
    BoxCollider2D cldr;


    public Transform wallCheckPointL, wallCheckPointR;
    public LayerMask whatIsGround;


    public static BlueMove Instance { get; set; }

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

        if (Physics2D.OverlapCircle(wallCheckPointL.position, .01f, whatIsGround) || Physics2D.OverlapCircle(wallCheckPointR.position, .01f, whatIsGround))
        {
            dir *= -1f;
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    }
}
