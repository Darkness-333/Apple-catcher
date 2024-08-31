using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float speed=1;
    [SerializeField] private float endPostionX=20;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if(transform.position.x>endPostionX) {
            Destroy(gameObject);
        }
    }
}
