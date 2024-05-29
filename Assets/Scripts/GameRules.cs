using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameRules : MonoBehaviour
{

    public float gameTimer = 60;
    public bool startTimer = false;
    public float displayTimeMinutes, displayTimeSeconds;
    public Text displayTime;
    public GameObject GameEndedUI;
    public GameObject GameUI;
    public TextMeshProUGUI accuracyText, scoreText, shotsMissedText, shotsHitText;
    public GameSettings gameSettings;

    void Start()
    {
        gameSettings = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        startTimer = true;
        DisplayTime(gameTimer);
        GameEndedUI.SetActive(false);
    }

    void DisplayTime(float gameTimer)
    {
        displayTimeMinutes = Mathf.FloorToInt(gameTimer / 60);
        displayTimeSeconds = Mathf.FloorToInt(gameTimer % 60);

        displayTime.text = string.Format("{0:00}:{1:00}", displayTimeMinutes, displayTimeSeconds);
    }


    void Update()
    {
       if(startTimer)
        {
            if(gameTimer > 0)
            {
                gameTimer -= Time.deltaTime;
                DisplayTime(gameTimer);
                //calculate score function
            }
            else
            {
                accuracyText.text = "Accuracy: " + Math.Round(gameSettings.accuracy, 2) + "%";
                scoreText.text = "Score: " + gameSettings.score;
                shotsHitText.text = "Shots hit: " + gameSettings.targetsHit;
                shotsMissedText.text = "Shots missed: " + gameSettings.missedShots;
                gameTimer = 0;
                DisplayTime(gameTimer);
                startTimer = false;
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                GameEndedUI.SetActive(true);
                GameUI.SetActive(false);
            }
        }
    }

}
