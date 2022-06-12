using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    private CircleCollider2D cldr;

    private void Awake()
    {
        cldr = GetComponent<CircleCollider2D>();
    }
    public void turnCollider(bool condition)
    {
        cldr.enabled = condition;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(Hero.Instance.gameObject == collision.gameObject)
        {
            Hero.Instance.GetDamage();
        }
    }
}
