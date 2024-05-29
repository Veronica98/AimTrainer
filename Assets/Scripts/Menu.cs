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
        gameSettings.noOfTargets = 4;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //in build jocul in sine are idx 1
    }

    public void LoadTrackingGameMode()
    {
        gameSettings = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        gameSettings.isMoving = true;
        gameSettings.isDecreasing = false;
        gameSettings.noOfTargets = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadGridshot()
    {
        gameSettings = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        gameSettings.isMoving = false;
        gameSettings.isDecreasing = false;
        gameSettings.noOfTargets = 3;
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
