using System;
using UnityEngine;

public class Apple : MonoBehaviour {

    [SerializeField] private static float bottomY = -20;

    public bool isUseful;
    public int pointsGive = 1;

    private GameController controller;

    private void Start() {
        controller = GameObject.Find("GameController").GetComponent<GameController>();

    }

    private void Update() {
        if (transform.position.y < bottomY) {
            if(isUseful) {
                controller.AppleDestroyed();
            }
            
            Destroy(gameObject);
        }
    }

}