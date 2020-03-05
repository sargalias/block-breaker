using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField] private float speed = 10;
    [SerializeField] private Vector2 initialDirection;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private float randomFactor;

    private Paddle paddle;
    private AudioSource audioSource;
    private Rigidbody2D rigidbody2D;

    private bool hasGameStarted = false;

    private void Start() {
        SetDefaults();
        paddle = FindObjectOfType<Paddle>();
        SetStickToPaddle();
        audioSource = GetComponent<AudioSource>();
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void SetDefaults() {
        if (initialDirection.magnitude == 0) {
            initialDirection = new Vector2(1, 1);
        }
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Launch();
        }
    }

    private void SetStickToPaddle() {
        paddle.Moved += OnPaddleMoved;
    }

    private void OnPaddleMoved(Vector2 position) {
        transform.position = new Vector2(position.x, transform.position.y);
    }

    private void Launch() {
        if (!hasGameStarted) {
            hasGameStarted = true;
            paddle.Moved -= OnPaddleMoved;
            rigidbody2D.velocity = initialDirection.normalized * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Vector2 velocityTweak = new Vector2(
            Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor)
        );
        if (hasGameStarted) {
            AudioClip clip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.PlayOneShot(clip);
            rigidbody2D.velocity += velocityTweak;
        }
    }
}
