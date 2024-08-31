using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySettings : MonoBehaviour {
    [SerializeField]private int levelNumber;
    [SerializeField] private List<LevelSettingsSO> levelSettings;
    
    public static int storedLevelNumber;


    private int nextLevelPoints;
    private List<AppleSettings> applesSettings;
    private List<AppleTreeSettings> appleTreesSettings;

    private void Awake() {
        if (storedLevelNumber > 0) {
            levelNumber = storedLevelNumber;
        }
        if (levelNumber > levelSettings.Count) {
            MusicPlayer.instance.audioSource.clip=MusicPlayer.instance.audioClips[1];
            MusicPlayer.instance.audioSource.Play();
            SceneManager.LoadScene("LevelsEnd");
        }
        else {
            LevelSettingsSO level = levelSettings[levelNumber - 1];
            nextLevelPoints = level.nextLevelPoints;
            applesSettings = level.applesSettings;
            appleTreesSettings = level.appleTreesSettings;

        }

    }


    public int GetNextLevelPoints() {
        return nextLevelPoints;
    }

    public List<AppleTreeSettings> GetAppleTreesSettings() {
        return appleTreesSettings;
    }

    public List<AppleSettings> GetApplesSettings() {
        return applesSettings;
    }

    public int GetLevelNumber() {
        return levelNumber;
    }

    public void SetLevelNumber(int newLevelNumber) {
        levelNumber = newLevelNumber;
        storedLevelNumber = newLevelNumber; 
    }

}


[Serializable]
public class AppleSettings {
    public string itemName;
    public Apple apple;
    public int pointsGive;
    [Range(0, 100)]
    public float spawnChance;
}

[Serializable]
public class AppleTreeSettings {
    // standart settings

    public float speed = 5;
    public float chanceToChangeDirection = 0.005f;
    public float startDelay = 1;
    public float secondsBetweenAppleDrops = 1;

    public void ResetToDefaultValues() {
        speed = 5f;
        chanceToChangeDirection = 0.005f;
        startDelay = 1f;
        secondsBetweenAppleDrops = 1f;
    }

}