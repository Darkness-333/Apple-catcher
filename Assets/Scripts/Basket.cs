
using System;
using TMPro;
using UnityEngine;

public class Basket : MonoBehaviour {

    private TextMeshProUGUI scoreText;

    private void Start() {
        scoreText=GameObject.Find("CurrentScore").GetComponent<TextMeshProUGUI>();
        scoreText.text = "0";
    }
    private void Update() {
        Vector3 mousePos2D=Input.mousePosition;

        mousePos2D.z=-Camera.main.transform.position.z;

        Vector3 mousePos3D=Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = transform.position;
        pos.x = mousePos3D.x;
        transform.position=pos;
    }
    private void OnCollisionEnter(Collision collision) {
        GameObject collidedWith=collision.gameObject;

        Apple apple = collidedWith.GetComponent<Apple>();

        if (apple!=null) {
            int score = int.Parse(scoreText.text);
            score+=apple.pointsGive;
            scoreText.text = score.ToString();

            if (score > HighScore.score) {
                HighScore.score = score;
            }
            Destroy(apple.gameObject);
        }


    }
}