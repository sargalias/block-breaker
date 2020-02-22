using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Paddle paddle;
    private Transform transform;

    private void Start() {
        paddle = FindObjectOfType<Paddle>();
        paddle.Moved += OnPaddleMoved;
        transform = gameObject.GetComponent<Transform>();
    }

    private void OnPaddleMoved(Vector2 position) {
        transform.position = new Vector2(position.x, transform.position.y);
    }
}
