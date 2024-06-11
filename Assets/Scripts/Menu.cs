using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameSettings gameSettings;
    [SerializeField] public GameObject SettingsUI, MenuUI;

    public void LoadSpeedGameMode()
    {
        gameSettings = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        gameSettings.isMoving = false;
        gameSettings.isDecreasing = true;
        gameSettings.isPrecision = false;
        gameSettings.noOfTargets = 4;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadTrackingGameMode()
    {
        gameSettings = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        gameSettings.isMoving = true;
        gameSettings.isDecreasing = false;
        gameSettings.isPrecision = false;
        gameSettings.noOfTargets = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadGridshot()
    {
        gameSettings = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        gameSettings.isMoving = false;
        gameSettings.isDecreasing = false;
        gameSettings.isPrecision = false;
        gameSettings.noOfTargets = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadPrecisionGameMode()
    {
        gameSettings = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        gameSettings.isMoving = false;
        gameSettings.isDecreasing = false;
        gameSettings.isPrecision = true;
        gameSettings.noOfTargets = 8;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void loadSettings()
    {
        SettingsUI.SetActive(true);
        MenuUI.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
