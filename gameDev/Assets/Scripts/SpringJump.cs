using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringJump : MonoBehaviour
{
    private float gravityStore;
    private Vector3 dir;
    private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 40f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        gravityStore = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetSpringJump();
        }
    }
}
