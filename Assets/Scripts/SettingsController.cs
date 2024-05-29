using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingsController : MonoBehaviour
{
    public GameSettings gameSettings;
    public GameObject MainMenuUI, SettingsUI;
    [SerializeField] Slider mouseSensitivitySlider;
    private static readonly string encryptionKey = "1926348";

    void Start()
    {
        gameSettings = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        mouseSensitivitySlider.value = gameSettings.mouseSensitivity;
    }

    public void SetMouseSensitivity()
    {
        
        gameSettings.mouseSensitivity = mouseSensitivitySlider.value;
    }

    public void SaveSettings()
    {
        string gameSettingsPath = Directory.GetCurrentDirectory() + "/GameSettings.json";
        SettingsUI.SetActive(false);
        MainMenuUI.SetActive(true);
        string decryptedData = JsonUtility.ToJson(gameSettings);
        string encryptedData = "";

        for(int i = 0; i < decryptedData.Length; i++)
        {
            encryptedData += (char)(decryptedData[i] ^ encryptionKey[i % encryptionKey.Length]);
        } 

        File.WriteAllText(gameSettingsPath, encryptedData);
    }


}
