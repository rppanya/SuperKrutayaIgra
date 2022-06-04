using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSpring : MonoBehaviour
{

    BoxCollider2D cldr;
    private Animator jumpAnim;
    public static GreenSpring Instance { get; set; }

    private void Awake()
    {
        Instance = this;
        cldr = GetComponent<BoxCollider2D>();
        jumpAnim = GetComponent<Animator>();
    }


    public void turnCollider(bool condition)
    {
        cldr.enabled = condition;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.SpringJump();
            jumpAnim.Play("greenSpring");
        }
        else
        {
            jumpAnim.Play("greenSpringIdle");
        }
    }
}
