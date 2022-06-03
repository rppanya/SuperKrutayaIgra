using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Image image;

    [Header("Properties")]
    [SerializeField] private int value;
    [SerializeField] private int maxValue = 100;
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
        image.fillAmount = (float)value / maxValue;
    }

    public void SetValue(int value) => this.value = value;
    public void SetMaxxValue(int maxValue) => this.maxValue = maxValue;
}
