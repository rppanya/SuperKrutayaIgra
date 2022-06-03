using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public bool blueCol = false, redCol = false, greenCol = false, yellowCol = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.turnColliders(blueCol, redCol, greenCol, yellowCol);
            Debug.Log("Portal");
        }
    }
}
