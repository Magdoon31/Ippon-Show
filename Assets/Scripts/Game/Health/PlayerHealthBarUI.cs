using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHealthBarUI : MonoBehaviour
{
    public player target;
    public Image HealthPlayer;
    public Image Border;
    public TMP_Text HPText;
    public Color newColor;
    void Update()
    {
        if (target != null) {
            HPText.text = Math.Round(target.health.precentHP).ToString() + "%";
            if (target.health.HPLevel == 3)
            { 
                if (ColorUtility.TryParseHtmlString("#44C03D", out newColor))
                {
                    Border.color = newColor;
                }
                if (ColorUtility.TryParseHtmlString("#58FF4E", out newColor))
                {
                    HealthPlayer.color = newColor;
                }
            }
            if (target.health.HPLevel == 2)
            {
                if (ColorUtility.TryParseHtmlString("#C0A63D", out newColor))
                {
                    Border.color = newColor;
                }
                if (ColorUtility.TryParseHtmlString("#FFDE4E", out newColor))
                {
                    HealthPlayer.color = newColor;
                }
            }

            if (target.health.HPLevel == 1)
            {
                if (ColorUtility.TryParseHtmlString("#FF5733", out newColor))
                {
                    Border.color = newColor;
                }
                if (ColorUtility.TryParseHtmlString("#C03D44", out newColor))
                {
                    HealthPlayer.color = newColor;
                }
            }
        }
    }
}