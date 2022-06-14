using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Image image;


    [Header("Properties")]
    
    [SerializeField] private bool isCorrectlyConfigured = false;

    private void Awake()
    {
        if (image.type == Image.Type.Filled & image.fillMethod == Image.FillMethod.Horizontal)
        {
            isCorrectlyConfigured = true;
        }
        else
        {
            Debug.Log(message: "{GameLog} => [ProgressBarController] - (<color=red>Error</color>) -> Components Parameters Ace Incorrectly Configured! \n" +
                "Required type: Filled \n" +
                "Required FillMethod: Horizontal");
        }
    }
    
    private void LateUpdate()
    {
        if (!isCorrectlyConfigured) return;
        float lives = Hero.Instance.GetLives();
        image.fillAmount = lives / 3.1f;
        if (image.fillAmount == 0)
        {
            //PauseMenu.Instance.Pause();
            //DeathCounter.upDeath();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
   
}
