using UnityEngine;

public class HighScore : MonoBehaviour {

    [SerializeField] private DifficultySettings difficultySettings;
    [SerializeField] private TextLocalizer textLocalizer;

    public static int score = 0;

    private readonly string highScoreKey = "HighScore_";

    private void Start() {
        score = GetHighScore();
    }

    private void Update() {
        textLocalizer.UpdateHighScore(score);
        if (score > GetHighScore()) {
            SaveHighScore(score);
        }
    }

    public void SaveHighScore(int score) {
        int levelNumber = difficultySettings.GetLevelNumber();
        string key = highScoreKey + levelNumber;

        int highScore = PlayerPrefs.GetInt(key, 0);

        if (score > highScore) {
            PlayerPrefs.SetInt(key, score);
            PlayerPrefs.Save();
        }
    }

    public int GetHighScore() {
        int levelNumber = difficultySettings.GetLevelNumber();
        string key = highScoreKey + levelNumber;
        return PlayerPrefs.GetInt(key, 0);
    }

}