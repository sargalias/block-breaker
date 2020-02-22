using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField]
    private float speed = 10;

    [SerializeField]
    private Vector2 initialDirection;

    private Paddle paddle;

    private void Start() {
        SetDefaults();
        paddle = FindObjectOfType<Paddle>();
        SetStickToPaddle();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Launch();
        }
    }

    private void SetDefaults() {
        if (initialDirection.magnitude == 0) {
            initialDirection = new Vector2(1, 1);
        }
    }

    private void SetStickToPaddle() {
        paddle.Moved += OnPaddleMoved;
    }

    private void OnPaddleMoved(Vector2 position) {
        transform.position = new Vector2(position.x, transform.position.y);
    }

    private void Launch() {
        paddle.Moved -= OnPaddleMoved;
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = initialDirection.normalized * speed;
    }
}
