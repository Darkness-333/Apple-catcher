using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.SceneManagement;
using YG;

public class GameController : MonoBehaviour {
    [SerializeField] private GameObject basketPrefab;
    [SerializeField] private AppleTree appleTreePrefab;
    [SerializeField] private DifficultySettings difficultySettings;
    [SerializeField] private GameObject hintText;

    private int numBaskets = 3;
    private float basketBottomY = -14;
    private float basketSpacingY = 2;
    private List<GameObject> basketList;

    private readonly string highScoreKey = "HighScore_";
    private readonly string levelNumberKey = "LevelNumber";


    void Start() {
        foreach (AppleTreeSettings elem in difficultySettings.GetAppleTreesSettings()) {
            Vector3 position = new Vector3(Random.Range(-20, 20), 10, 0);
            AppleTree appleTree = Instantiate(appleTreePrefab, position, Quaternion.identity);
            appleTree.SetSettings(difficultySettings.GetApplesSettings(),
                elem.speed, elem.chanceToChangeDirection, elem.startDelay, elem.secondsBetweenAppleDrops);
        }

        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++) {
            GameObject basket = Instantiate(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + basketSpacingY * i;
            basket.transform.position = pos;
            basketList.Add(basket);
        }
    }



    private void Update() {
        if (GetHighScore() >= difficultySettings.GetNextLevelPoints()) {
            hintText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space)) {
                int nextLevelNumber=difficultySettings.GetLevelNumber()+1;
                difficultySettings.SetLevelNumber(nextLevelNumber);
                PlayerPrefs.SetInt(levelNumberKey,nextLevelNumber);
                HighScore.score = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("Pause");
        }
    }

    public void AppleDestroyed() {
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject apple in appleArray) {
            Destroy(apple);
        }
        GameObject basket = basketList[basketList.Count - 1];
        basketList.Remove(basket);
        Destroy(basket);

        if (basketList.Count == 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private int GetHighScore() {
        int levelNumber = difficultySettings.GetLevelNumber();
        string key = highScoreKey + levelNumber;
        return PlayerPrefs.GetInt(key, 0);
    }
}
