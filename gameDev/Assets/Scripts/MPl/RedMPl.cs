using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMPl : MonoBehaviour
{
    private float speed = 5f, dirF = 1f;
    private bool heroOnPlatform;
    private Vector3 dir;
    BoxCollider2D cldr;
    [SerializeField] string direction;


    public Transform wallCheckPointL, wallCheckPointR;
    public LayerMask whatIsGround;


    public static RedMPl Instance { get; set; }

    private void Awake()
    {
        Instance = this;
        cldr = GetComponent<BoxCollider2D>();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Hero.Instance.gameObject == collision.gameObject)
        {
            heroOnPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        heroOnPlatform = false;
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
    private void Move()
    {
        if (Physics2D.OverlapCircle(wallCheckPointL.position, .1f, whatIsGround) || Physics2D.OverlapCircle(wallCheckPointR.position, .1f, whatIsGround))
        {
            dir *= -1f;
            dirF *= -1f;
        }
        if (direction == "horizontal")
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
            if (heroOnPlatform)
            {
                Hero.Instance.transform.position = Vector3.MoveTowards(Hero.Instance.transform.position, Hero.Instance.transform.position + dir, speed * Time.deltaTime);
            }
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + Time.deltaTime * speed * dirF);
            if (heroOnPlatform)
            {
                Hero.Instance.transform.position = new Vector2(Hero.Instance.transform.position.x, Hero.Instance.transform.position.y + Time.deltaTime * speed * dirF);
            }
        }
    }
}
