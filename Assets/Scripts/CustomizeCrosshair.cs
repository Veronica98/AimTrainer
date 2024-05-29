using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeCrosshair : MonoBehaviour
{
    [SerializeField] private RectTransform Center, Top, Bottom, Right, Left;
    [SerializeField] private RawImage riCenter, riTop, riBottom, riRight, riLeft;
    [SerializeField] public GameSettings gameSettings;

    [SerializeField] Toggle centerToggle;
    [SerializeField] Slider centerThicknessSlider, thicknessSlider, verticalValueSlider, horizontalValueSlider, gapSlider; 

    void Start()
    {
        gameSettings = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        centerToggle.isOn = gameSettings.showCrosshairCenter;
        centerThicknessSlider.value = gameSettings.centerThickness;
        thicknessSlider.value = gameSettings.thickness;
        verticalValueSlider.value = gameSettings.verticalCrosshairValue;
        horizontalValueSlider.value = gameSettings.horizontalCrosshairValue;
        gapSlider.value = gameSettings.gap;
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
        Top.anchoredPosition = new Vector3(0f, gapSlider.value, 0f);
        Bottom.anchoredPosition = new Vector3(0f, -gapSlider.value, 0f);
        Left.anchoredPosition = new Vector3(gapSlider.value, 0f, 0f);
        Right.anchoredPosition = new Vector3(-gapSlider.value, 0f, 0f);
        gameSettings.gap = gapSlider.value;
    }

    /*public void CustomiseCrosshair()
    {
        if (showCrosshairCenter == true)
        {
            Center.sizeDelta = new Vector2(centerThickness, centerCrosshairValue);
        }
        else
        {
            Center.sizeDelta = new Vector2(0, 0);
        };

        Top.sizeDelta = new Vector2(thickness, topCrosshairValue);
        Bottom.sizeDelta = new Vector2(thickness, bottomCrosshairValue);
        Left.sizeDelta = new Vector2(leftCrosshairValue, thickness);
        Right.sizeDelta = new Vector2(rightCrosshairValue, thickness);

        Top.anchoredPosition = new Vector3(0f, gap, 0f);
        Bottom.anchoredPosition = new Vector3(0f, -gap, 0f);
        Left.anchoredPosition = new Vector3(-gap, 0f, 0f);
        Right.anchoredPosition = new Vector3(gap, 0f, 0f);

        riCenter.color = riTop.color = riBottom.color = riRight.color = riLeft.color = Color.green;
    }*/
    
    void Update()
    {
       
    }
}
