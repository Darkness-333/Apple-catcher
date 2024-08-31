using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using YG;

public class TextLocalizer : MonoBehaviour
{
    [SerializeField] private DifficultySettings difficultySettings; 
    [SerializeField] private TextMeshProUGUI Level; 
    [SerializeField] private TextMeshProUGUI HighScore; 
    [SerializeField] private TextMeshProUGUI NextLevel; 

    private string highScoreKey = "HighScore_";
    private string tableName = "UI Text";

    private LocalizedString localizedHighScoreString;

    void Start() {
        int levelNumber = difficultySettings.GetLevelNumber();
        int highScore = PlayerPrefs.GetInt(highScoreKey + levelNumber, 0);
        int nextLevelPoints = difficultySettings.GetNextLevelPoints();

        if (Level.GetComponent<LanguageYG>()) {
            Level.GetComponent<LanguageYG>().additionalText.additionalText = " " + levelNumber;
        }
        else {
            // Настройка локализованной строки для уровня
            LocalizedString localizedLevelString = new LocalizedString { TableReference = tableName, TableEntryReference = "Level" };
            localizedLevelString.Arguments = new object[] { levelNumber };
            localizedLevelString.StringChanged += UpdateLevel;
            UpdateLevel(localizedLevelString.GetLocalizedString());

        }
        
        if (HighScore.GetComponent<LanguageYG>() ) {
            HighScore.GetComponent<LanguageYG>().additionalText.additionalText = " " + highScore;
        }
        else {
            // Настройка локализованной строки для рекорда
            localizedHighScoreString = new LocalizedString { TableReference = tableName, TableEntryReference = "HighScore" };
            localizedHighScoreString.Arguments = new object[] { highScore };
            localizedHighScoreString.StringChanged += UpdateHighScore;
            UpdateHighScore(localizedHighScoreString.GetLocalizedString());

        }

        if (NextLevel.GetComponent<LanguageYG>()) {
            NextLevel.GetComponent<LanguageYG>().additionalText.additionalText = " " + nextLevelPoints;
        }
        else {
            // Настройка локализованной строки для следующего уровня
            LocalizedString localizedNextLevelString = new LocalizedString { TableReference = tableName, TableEntryReference = "NextLevel" };
            localizedNextLevelString.Arguments = new object[] { nextLevelPoints };
            localizedNextLevelString.StringChanged += UpdateNextLevel;
            UpdateNextLevel(localizedNextLevelString.GetLocalizedString());
        }

    }

    void UpdateLevel(string localizedString) {
        Level.SetText(localizedString);
    }

    void UpdateHighScore(string localizedString) {
        HighScore.SetText(localizedString);
    }

    public void UpdateHighScore(int highScore) {
        if (HighScore.GetComponent<LanguageYG>()) {
            HighScore.GetComponent<LanguageYG>().additionalText.additionalText = " " + highScore;
        }
        else {
            localizedHighScoreString.Arguments = new object[] { highScore };
            HighScore.SetText(localizedHighScoreString.GetLocalizedString());

        }
    }

    void UpdateNextLevel(string localizedString) {
        NextLevel.SetText(localizedString);
    }


}
