using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public bool isPaused;
    public GameObject PauseMenu;
    public GameObject GameUI;
    private GameSettings gameSettings;
    private int noOfTargetsOnCurrentGameMode;

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        PauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameSettings.score = gameSettings.missedShots = gameSettings.targetsHit = 0;
        gameSettings.accuracy = 100;
        gameSettings.noOfTargets = noOfTargetsOnCurrentGameMode;
        SceneManager.LoadScene(1);
    }

    public void QuitToMainMenu()
    {
        gameSettings.score = gameSettings.missedShots = gameSettings.targetsHit = 0;
        gameSettings.accuracy = 100;
        SceneManager.LoadScene(0);
    }

    private void Start()
    {
        Time.timeScale = 1f;
        gameSettings = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        noOfTargetsOnCurrentGameMode = gameSettings.noOfTargets;
        if (isPaused == false)
        {
            PauseMenu.SetActive(false);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else 
            {
                Cursor.lockState = CursorLockMode.None;
                PauseMenu.SetActive(true);
                isPaused = true;
                Time.timeScale = 0f;
            }
        }
    }
}
