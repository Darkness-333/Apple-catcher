using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour {

    [SerializeField] private float amplitude = 1.0f; 
    [SerializeField] private float frequency = 1.0f; 
    [SerializeField] private float speed = 1.0f;     
    [SerializeField] private float returnPosX=3;

    private Vector3 startPosition;

    void Start() {
        startPosition = transform.position;
    }

    void Update() {

        float wave = Mathf.Sin(Time.time * frequency) * amplitude;
        Vector3 pos = new Vector3(transform.position.x+speed*Time.deltaTime, startPosition.y+ wave, 0);
        transform.position = pos;


        if(transform.position.x>returnPosX) {
            transform.position = transform.position - Vector3.right * transform.position.x;
        }
    }
}




