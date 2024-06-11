using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeCrosshair : MonoBehaviour
{
    [SerializeField] private RectTransform Center, Top, Bottom, Right, Left;
    [SerializeField] private RawImage riCenter, riTop, riBottom, riRight, riLeft;
    [SerializeField] public GameSettings gameSettings;
    [SerializeField] TMP_Dropdown crosshairColorSelector;
    [SerializeField] Toggle centerToggle;
    [SerializeField] Slider centerThicknessSlider, thicknessSlider, verticalValueSlider, horizontalValueSlider, gapSlider;
    Dictionary<int, List<float>> colorOptions = new Dictionary<int, List<float>> { 
                                                { 0, new List<float> { 255f, 0f, 0f } }, 
                                                { 1, new List<float> { 100f, 0f, 200f } }, 
                                                { 2, new List<float> { 255f, 255f, 0f} }, 
                                                { 3, new List<float> { 0f, 255f, 0f } }, 
                                                { 4, new List<float> { 0f, 0f, 0f } } };
        
    void Start()
    {
        gameSettings = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        centerToggle.isOn = gameSettings.showCrosshairCenter;
        centerThicknessSlider.value = gameSettings.centerThickness;
        thicknessSlider.value = gameSettings.thickness;
        verticalValueSlider.value = gameSettings.verticalCrosshairValue;
        horizontalValueSlider.value = gameSettings.horizontalCrosshairValue;
        gapSlider.value = gameSettings.gap;
        crosshairColorSelector.value = gameSettings.crosshairColor;
    }
    public void EnableCenter()
    {
        if (centerToggle.isOn)
        {
            Center.sizeDelta = new Vector2(gameSettings.centerThickness, gameSettings.centerThickness);
        }
        else
        {
            Center.sizeDelta = new Vector2(0, 0);
        }
        gameSettings.showCrosshairCenter = centerToggle.isOn;
    }

    public void CenterThickness()
    {
        Center.sizeDelta = new Vector2(centerThicknessSlider.value, centerThicknessSlider.value);
        gameSettings.centerThickness = centerThicknessSlider.value;
        if (gameSettings.centerThickness > 0)
        {
            centerToggle.isOn = true;
        }
        else
        {
            centerToggle.isOn = false;
        }
        gameSettings.showCrosshairCenter = centerToggle.isOn;
    }

    public void Thickness()
    {
        Top.sizeDelta = new Vector2(thicknessSlider.value, gameSettings.verticalCrosshairValue);
        Bottom.sizeDelta = new Vector2(thicknessSlider.value, gameSettings.verticalCrosshairValue);
        Left.sizeDelta = new Vector2(gameSettings.horizontalCrosshairValue, thicknessSlider.value);
        Right.sizeDelta = new Vector2(gameSettings.horizontalCrosshairValue, thicknessSlider.value);
        gameSettings.thickness = thicknessSlider.value;
    }

    public void VerticalValue()
    {
        Top.sizeDelta = new Vector2(gameSettings.thickness, verticalValueSlider.value);
        Bottom.sizeDelta = new Vector2(gameSettings.thickness, verticalValueSlider.value);
        gameSettings.verticalCrosshairValue = verticalValueSlider.value;
    }

    public void HorizontalValue()
    {
        Left.sizeDelta = new Vector2(horizontalValueSlider.value, gameSettings.thickness);
        Right.sizeDelta = new Vector2(horizontalValueSlider.value, gameSettings.thickness);
        gameSettings.horizontalCrosshairValue = horizontalValueSlider.value;
    }

    public void Gap()
    {
        Top.anchoredPosition = new Vector2(0f, gapSlider.value);
        Bottom.anchoredPosition = new Vector2(0f, -gapSlider.value);
        Left.anchoredPosition = new Vector2(gapSlider.value, 0f);
        Right.anchoredPosition = new Vector2(-gapSlider.value, 0f);
        gameSettings.gap = gapSlider.value;
    }


    public void SetCrosshairColor()
    {
        riCenter.color = riTop.color = riBottom.color = riRight.color = riLeft.color = new Color(colorOptions[crosshairColorSelector.value][0], 
                                                                                            colorOptions[crosshairColorSelector.value][1], 
                                                                                            colorOptions[crosshairColorSelector.value][2]);
        gameSettings.crosshairColor = crosshairColorSelector.value;
    }

}
