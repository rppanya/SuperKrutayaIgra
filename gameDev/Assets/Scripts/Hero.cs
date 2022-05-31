using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Entity
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private float lives = 5f;
    [SerializeField] private float jumpForce = 15f;
    private bool isGrounded = false;
    public bool faceRight = true;
    public GameObject Boost;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator cloudanim;
    public GameObject Cloud;

    public static Hero Instance { get; set; }

    private Animator anim;

    public override void GetDamage()
    {
        lives -= 1;
        Debug.Log(lives);

        /*if(lives < 1)
        {
            Die();
        }*/
    }

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Cloud = GameObject.Find("Cloud");
    }

    private void FixedUpdate()
    {
        CheckGround();
    }


    private void Update()
    {
        if (isGrounded) State = States.idle;
        if (Input.GetButton("Horizontal"))
        {
            Run();
        }
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Run()
    {
        if (isGrounded) State = States.walking;

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        if ((dir.x > 0 && !faceRight) || (dir.x < 0 && faceRight))
        {
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
            faceRight = !faceRight;
        }
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        sprite.enabled = false;
        Boost = Instantiate(Resources.Load("Prefabs/Cloud"), transform.position, transform.rotation) as GameObject;
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.9f);
        isGrounded = collider.Length > 1;
        if (!isGrounded) State = States.jump;
        else
        {
            sprite.enabled = true;
        }
    }

    public enum States
    {
        idle,
        walking,
        jump
    }
}
