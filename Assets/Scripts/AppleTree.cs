using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AppleTree : MonoBehaviour {
    //public GameObject applePrefab;

    private float speed = 5;
    private float chanceToChangeDirection = 0.005f;
    private float startDelay = 1;
    private float secondsBetweenAppleDrops = 1;

    private List<AppleSettings> appleSettings;

    private float leftAndRightEdge = 20;

    void Start() {
        InvokeRepeating(nameof(DropApple), startDelay, secondsBetweenAppleDrops);
    }
    private void DropApple() {
        float totalWeight = 0;

        // Суммируем все вероятности
        foreach (AppleSettings elem in appleSettings) {
            totalWeight += elem.spawnChance;
        }

        // Генерируем случайное число от 0 до общего веса
        float randomValue = Random.Range(0, totalWeight);

        // Проходим по списку и выбираем предмет
        float cumulativeWeight = 0;
        Apple apple = null;

        foreach (AppleSettings elem in appleSettings) {
            cumulativeWeight += elem.spawnChance;
            if (randomValue <= cumulativeWeight) {
                apple = elem.apple;
                apple.pointsGive = elem.pointsGive;
                break;
            }
        }

        Instantiate(apple, transform.position, Quaternion.identity);
    }

    public void SetSettings(List<AppleSettings> appleSettings, float speed, float chanceToChangeDirection, float startDelay, float secondsBetweenAppleDrops) {

        this.appleSettings = appleSettings;
        this.speed = speed;
        this.chanceToChangeDirection = chanceToChangeDirection;
        this.startDelay = startDelay;
        this.secondsBetweenAppleDrops = secondsBetweenAppleDrops;
    }

    void Update() {
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x + speed * Time.deltaTime, -leftAndRightEdge, leftAndRightEdge);
        transform.position = newPosition;
        if (Mathf.Abs(newPosition.x) == leftAndRightEdge) {
            speed *= -1;
        }

    }

    private void FixedUpdate() {
        if (Random.value < chanceToChangeDirection) {
            speed *= -1;
        }
    }
}
