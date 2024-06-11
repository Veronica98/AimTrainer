using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GameSettings : MonoBehaviour
{
    public static GameSettings instance;

    public int noOfTargets = 3, crosshairColor;
    public double score = 0;
    public float missedShots, targetsHit = 0;
    public float accuracy = 100;
    public bool isMoving, isDecreasing, isPrecision;
    public float thickness, centerThickness, centerCrosshairValue, verticalCrosshairValue, horizontalCrosshairValue, gap, mouseSensitivity, volumeValue;
    public bool showCrosshairCenter;
    private static readonly string encryptionKey = "1926348";

    private void Awake()
    {
        
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        string gameSettingsPath = Directory.GetCurrentDirectory() + "/GameSettings.json";
        if (File.Exists(gameSettingsPath))
        {
            string encryptedData = File.ReadAllText(gameSettingsPath);
            string decryptedData = "";

            for(int i = 0; i < encryptedData.Length; i++)
            {
                decryptedData += (char) (encryptedData[i] ^ encryptionKey[i % encryptionKey.Length]);
            }

            JsonUtility.FromJsonOverwrite(decryptedData, instance);
        }
        else
        {
            InitializeGameSettingsWithDefaultValues();
            string decryptedData = JsonUtility.ToJson(instance);
            string encryptedData = "";

            for (int i = 0; i < decryptedData.Length; i++)
            {
                encryptedData += (char) (decryptedData[i] ^ encryptionKey[i % encryptionKey.Length]);
            }

            File.WriteAllText(gameSettingsPath, encryptedData);
        }
    }

    private void InitializeGameSettingsWithDefaultValues()
    {
        thickness = 2;
        centerThickness = 2;
        centerCrosshairValue = 2;
        verticalCrosshairValue = 8;
        horizontalCrosshairValue = 8;
        gap = 2;
        showCrosshairCenter = true;
        mouseSensitivity = 700f;
        volumeValue = 2f;
        crosshairColor = 0;
    }
}
