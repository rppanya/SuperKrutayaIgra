using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public bool blueCol = false, redCol = false, greenCol = false, yellowCol = false;
    public GameObject trancisionPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.turnColliders(blueCol, redCol, greenCol, yellowCol);
            Animator anim = trancisionPanel.GetComponent<Animator>();
            anim.Play("portalTrancision");
            Debug.Log("Portal");
            //anim.Play("NewState");
        }
        
    }
}
