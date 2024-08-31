using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class StartGame : MonoBehaviour
{

    private readonly string levelNumberKey = "LevelNumber";


    private void Start() {
        YandexGame.GameReadyAPI();

        DifficultySettings.storedLevelNumber=PlayerPrefs.GetInt(levelNumberKey,1);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("Game");
        }
    }
}
