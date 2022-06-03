using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Entity
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lives = 3f;
    [SerializeField] private float jumpForce = 22f;

    BluePlatform[] bluePlatforms;
    RedPlatform[] redPlatforms;
    GreenPlatform[] greenPlatforms;
    YellowPlatform[] yellowPlatforms;
    RedSpike[] redSpikes;
    BlueSpike[] blueSpikes;
    GreenSpike[] greenSpikes;
    YellowSpike[] yellowSpikes;
    RedLaser[] redLasers;
    BlueLaser[] blueLasers;
    GreenLaser[] greenLasers;
    YellowLaser[] yellowLasers;
    RedSpring[] redSprings;
    BlueSpring[] blueSprings;
    GreenSpring[] greenSprings;
    YellowSpring[] yellowSprings;


    public Transform groundCheckPoint;
    private bool isGrounded = false;
    public bool faceRight = true;
    public GameObject Boost;
    public LayerMask whatIsGround;

    public Transform wallGrabPoint;
    private bool canGrab, isGrabbing;
    private float gravityStore;
    public float wallJumpTime = .3f;
    private float wallJumpCounter;


    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator cloudanim;
    public GameObject Cloud;

    public static Hero Instance { get; set; }

    private Animator anim;

    public void turnColliders(bool blueCon, bool redCon, bool greenCon, bool yellowCon)
    {
        //platforms
        foreach (BluePlatform block in bluePlatforms)
        {
            block.turnCollider(blueCon);
        }

        foreach (RedPlatform block in redPlatforms)
        {
            block.turnCollider(redCon);
        }

        foreach (GreenPlatform block in greenPlatforms)
        {
            block.turnCollider(greenCon);
        }

        foreach (YellowPlatform block in yellowPlatforms)
        {
            block.turnCollider(yellowCon);
        }


        //spikes
        foreach (BlueSpike spike in blueSpikes)
        {
            spike.turnCollider(blueCon);
        }

        foreach (RedSpike spike in redSpikes)
        {
            spike.turnCollider(redCon);
        }

        foreach (GreenSpike spike in greenSpikes)
        {
            spike.turnCollider(greenCon);
        }

        foreach (YellowSpike spike in yellowSpikes)
        {
            spike.turnCollider(yellowCon);
        }


        //lasers
        foreach(BlueLaser laser in blueLasers)
        {
            laser.turnCollider(blueCon);
        }

        foreach (RedLaser laser in redLasers)
        {
            laser.turnCollider(redCon);
        }

        foreach (GreenLaser laser in greenLasers)
        {
            laser.turnCollider(greenCon);
        }

        foreach (YellowLaser laser in yellowLasers)
        {
            laser.turnCollider(yellowCon);
        }


        //springs
        foreach(BlueSpring spring in blueSprings)
        {
            spring.turnCollider(blueCon);
        }

        foreach (RedSpring spring in redSprings)
        {
            spring.turnCollider(redCon);
        }

        foreach (GreenSpring spring in greenSprings)
        {
            spring.turnCollider(greenCon);
        }

        foreach (YellowSpring spring in yellowSprings)
        {
            spring.turnCollider(yellowCon);
        }
    }

    public override void GetDamage()
    {
        lives -= 1;
        Debug.Log(lives);
    }

    public void SpringJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce * 1.5f);
    }

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    private void Awake()
    {
        bluePlatforms = Object.FindObjectsOfType<BluePlatform>();
        redPlatforms = Object.FindObjectsOfType<RedPlatform>();
        greenPlatforms = Object.FindObjectsOfType<GreenPlatform>();
        yellowPlatforms = Object.FindObjectsOfType<YellowPlatform>();
        redSpikes = Object.FindObjectsOfType<RedSpike>();
        blueSpikes = Object.FindObjectsOfType<BlueSpike>();
        greenSpikes = Object.FindObjectsOfType<GreenSpike>();
        yellowSpikes = Object.FindObjectsOfType<YellowSpike>();
        redLasers = Object.FindObjectsOfType<RedLaser>();
        blueLasers = Object.FindObjectsOfType<BlueLaser>();
        greenLasers = Object.FindObjectsOfType<GreenLaser>();
        yellowLasers = Object.FindObjectsOfType<YellowLaser>();
        redSprings = Object.FindObjectsOfType<RedSpring>();
        blueSprings = Object.FindObjectsOfType<BlueSpring>();
        greenSprings = Object.FindObjectsOfType<GreenSpring>();
        yellowSprings = Object.FindObjectsOfType<YellowSpring>();


        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Cloud = GameObject.Find("Cloud");
    }

    /* private void FixedUpdate()
     {
         CheckGround();
     }*/

    public enum States
    {
        idle,
        walking,
        jump
    }

    private void Start()
    {
        turnColliders(true, false, false, false);
        gravityStore = rb.gravityScale;
    }
    private void Update()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);
        if (wallJumpCounter <= 0)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);
            if (!isGrounded) State = States.jump;
            if (isGrounded) State = States.idle;
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);

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
                if (isGrounded) State = States.walking;
            }
            else if (rb.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1f, 1, 1f);
                if (isGrounded) State = States.walking;
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
                rb.gravityScale = 10f;
                rb.velocity = Vector2.zero;
                State = States.idle;

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

        if ((dir.x > 0 && !faceRight) || (dir.x < 0 && faceRight))
        {
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
            faceRight = !faceRight;
        }
    }
        //sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
/*        sprite.enabled = false;*/
    }

    /*private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.9f);
        isGrounded = collider.Length > 1;
        if (!isGrounded) State = States.jump;
*//*        else
        {
            sprite.enabled = true;
        }*//*
    }*/
