using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Entity
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private float lives = 5f;
    [SerializeField] private float jumpForce = 40f;

    BluePlatform[] blues;
    RedPlatform[] reds;
    GreenPlatform[] greens;



    public Transform groundCheckPoint;
    private bool isGrounded = false;
    public bool faceRight = true;
    public GameObject Boost;
    public LayerMask whatIsGround;

    public Transform wallGrabPoint;
    private bool canGrab, isGrabbing;
    private float gravityStore;
    public float wallJumpTime = .2f;
    private float wallJumpCounter;


    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator cloudanim;
    public GameObject Cloud;

    public static Hero Instance { get; set; }

    private Animator anim;

    public void turnColliders(bool blueCon, bool redCon, bool greenCon)
    {
        foreach (BluePlatform block in blues)
        {
            block.turnCollider(blueCon);
        }

        foreach (RedPlatform block in reds)
        {
            block.turnCollider(redCon);
        }

        foreach (GreenPlatform block in greens)
        {
            block.turnCollider(greenCon);
        }
    }

    public override void GetDamage()
    {
        lives -= 1;
        Debug.Log(lives);
    }

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    private void Awake()
    {
        blues = Object.FindObjectsOfType<BluePlatform>();
        reds = Object.FindObjectsOfType<RedPlatform>();
        greens = Object.FindObjectsOfType<GreenPlatform>();
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Cloud = GameObject.Find("Cloud");
        turnColliders(false, true, false);
    }

    /* private void FixedUpdate()
     {
         CheckGround();
     }*/

    private void Start()
    {
        gravityStore = rb.gravityScale;
    }
    private void Update()
    {
        if (isGrounded) State = States.idle;
        if (Input.GetButton("Horizontal"))
        if (wallJumpCounter <= 0)
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

            /*if (Input.GetButton("Horizontal"))
            {
                Run();
            }*/
            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                Boost = Instantiate(Resources.Load("Prefabs/Cloud"), transform.position, transform.rotation) as GameObject;
            }
            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
            }

            if (rb.velocity.x > 0)
            {
                transform.localScale = Vector3.one;
            }
            else if (rb.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1f, 1, 1f);
            }

            //handle wall jumping
            canGrab = Physics2D.OverlapCircle(wallGrabPoint.position, .2f, whatIsGround);

            isGrabbing = false;
            if (canGrab && !isGrounded)
            {
                if ((transform.localScale.x == 1f && Input.GetAxisRaw("Horizontal") > 0) || (transform.localScale.x == -1f && Input.GetAxisRaw("Horizontal") < 0))
                {
                    isGrabbing = true;
                }
            }

            if (isGrabbing)
            {
                rb.gravityScale = 5f;
                rb.velocity = Vector2.zero;

                if (Input.GetButtonDown("Jump"))
                {
                    wallJumpCounter = wallJumpTime;
                    rb.velocity = new Vector2(-Input.GetAxisRaw("Horizontal") * speed, jumpForce);
                    rb.gravityScale = gravityStore;
                    isGrabbing = false;
                }
            }
            else
            {
                rb.gravityScale = gravityStore;
            }
        }
        else
        {
            wallJumpCounter -= Time.deltaTime;
        }
    }

    /*private void Run()
    {
        if (isGrounded) State = States.walking;

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

<<<<<<< Updated upstream
        if ((dir.x > 0 && !faceRight) || (dir.x < 0 && faceRight))
        {
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
            faceRight = !faceRight;
        }
    }
=======
        //sprite.flipX = dir.x < 0.0f;
    }*/

   /* private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
/*        sprite.enabled = false;*/
        Boost = Instantiate(Resources.Load("Prefabs/Cloud"), transform.position, transform.rotation) as GameObject;
    }*/

   /* private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.9f);
        isGrounded = collider.Length > 1;
<<<<<<< Updated upstream
        if (!isGrounded) State = States.jump;
/*        else
        {
            sprite.enabled = true;
        }*/
    }

=======
    }*/
        public enum States
    {
        idle,
        walking,
        jump
    }
}
