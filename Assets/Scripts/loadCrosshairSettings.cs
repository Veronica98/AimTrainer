using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCrosshairSettings : MonoBehaviour
{
    private GameSettings gameSettings;
    [SerializeField] private RectTransform Center, Top, Bottom, Right, Left;

    void Start()
    {
        gameSettings = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        if (gameSettings.showCrosshairCenter)
        {
            Center.sizeDelta = new Vector2(gameSettings.centerThickness, gameSettings.centerThickness);
        }
        else
        {
            Center.sizeDelta = new Vector2(0, 0);
        };

        Top.sizeDelta = new Vector2(gameSettings.thickness, gameSettings.verticalCrosshairValue);
        Bottom.sizeDelta = new Vector2(gameSettings.thickness, gameSettings.verticalCrosshairValue);
        Left.sizeDelta = new Vector2(gameSettings.horizontalCrosshairValue, gameSettings.thickness);
        Right.sizeDelta = new Vector2(gameSettings.horizontalCrosshairValue, gameSettings.thickness);

        Top.anchoredPosition = new Vector3(0f, gameSettings.gap, 0f);
        Bottom.anchoredPosition = new Vector3(0f, -gameSettings.gap, 0f);
        Left.anchoredPosition = new Vector3(-gameSettings.gap, 0f, 0f);
        Right.anchoredPosition = new Vector3(gameSettings.gap, 0f, 0f);
    }
}
