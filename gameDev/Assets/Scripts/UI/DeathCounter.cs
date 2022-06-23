using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathCounter : MonoBehaviour
{
    private static int deathCount = 0;
    [SerializeField] TextMeshProUGUI textUIDeathCount;
    public static DeathCounter deathCounter;
    public static DeathCounter Instance { get; set; }

    private void Start()
    {
        deathCounter = this;
    }
    public static void drawText()
    {
        deathCounter.textUIDeathCount.text = "" + deathCount;
    }
    private void Update()
    {
        deathCounter.textUIDeathCount.text = "" + deathCount;
    }

    public static void resetDeathCount()
    {
        deathCount = 0;
        drawText();
    }

    public static void upDeath()
    {
        deathCount++;
        drawText();
    }
}