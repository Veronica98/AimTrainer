using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadCrosshairSettings : MonoBehaviour
{
    private GameSettings gameSettings;
    [SerializeField] private RectTransform Center, Top, Bottom, Right, Left;
    [SerializeField] private RawImage riCenter, riTop, riBottom, riRight, riLeft;
    Dictionary<int, List<float>> colorOptions = new Dictionary<int, List<float>> { { 0, new List<float> { 255f, 0f, 0f } }, 
                                                { 1, new List<float> { 100f, 0f, 200f } }, 
                                                { 2, new List<float> { 255f, 255f, 0f } }, 
                                                { 3, new List<float> { 0f, 255f, 0f } }, 
                                                { 4, new List<float> { 0f, 0f, 0f } } };

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

        riCenter.color = riTop.color = riBottom.color = riRight.color = riLeft.color = new Color(colorOptions[gameSettings.crosshairColor][0], 
                                                                                        colorOptions[gameSettings.crosshairColor][1], 
                                                                                        colorOptions[gameSettings.crosshairColor][2]);
    }
}
