using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float lives = 3;
    [SerializeField] private float jumpForce = 15f;
    private bool isGrounded = false;
    public GameObject Boost;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator cloudanim;
    public GameObject Cloud;

    private Animator anim;

    private void Awake()
    {
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
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        Boost = Instantiate(Resources.Load("Prefabs/Cloud"), transform.position, transform.rotation) as GameObject;
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.9f);
        isGrounded = collider.Length > 1;
    }
}
