using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSpring : MonoBehaviour
{
    BoxCollider2D cldr;
    private Animator jumpAnim;
    public static BlueSpring Instance { get; set; }

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
            jumpAnim.Play("blueSpring");
            Hero.Instance.SpringJump();
        }
        else
        {
            jumpAnim.Play("blueSpringIdle");
        }
    }
}
