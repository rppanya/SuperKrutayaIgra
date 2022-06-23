using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class TransitionTrigger : MonoBehaviour
{
    public int id;
    //public GameObject trancisionPanel;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
       /* Animator anim = trancisionPanel.GetComponent<Animator>();
        anim.Play("transitionClose");


        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("transitionClose"))
        {*/
            SceneManager.LoadScene(id);
            Time.timeScale = 1f;
       // }

    }
}
