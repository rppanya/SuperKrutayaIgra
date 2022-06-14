using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMPl : MonoBehaviour
{
    private float speed = 7f;
    private int i;

    BoxCollider2D cldr;
    [SerializeField] string direction;
    public Transform[] points;

    public static RedMPl Instance { get; set; }

    private void Awake()
    {
        Instance = this;
        cldr = GetComponent<BoxCollider2D>();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.transform.parent = null;
        }
    }

    public void turnCollider(bool condition)
    {
        cldr.enabled = condition;
    }

    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if(i == points.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }
}
