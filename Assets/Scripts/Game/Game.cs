using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour {
    [SerializeField]
    private TextMeshProUGUI scoreDisplay;

    [SerializeField]
    private int pointsPerBlockDestoryed;

    [Range(0.1f, 10f)]
    [SerializeField]
    private float gameSpeed = 1f;

    private int currentScore = 0;
    private Level level;
    private SceneLoader sceneLoader;

    private void Awake() {
        int selfCount = FindObjectsOfType<Game>().Length;
        if (selfCount > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() {
        initialize();
    }

    private void Update() {
        Time.timeScale = gameSpeed;
        updateScore();
    }

    private void initialize() {
        sceneLoader = FindObjectOfType<SceneLoader>();

        level = FindObjectOfType<Level>();
        level.OnLevelWin += HandleLevelWin;
        level.OnBlockDestroyed += HandleBlockDestroyed;

        updateScore();
    }

    private void HandleLevelWin() {
        sceneLoader.LoadNextScene();
        initialize();
    }

    IEnumerator ReInitialize() {
        yield return null;
        initialize();
    }

    private void HandleBlockDestroyed() {
        currentScore += pointsPerBlockDestoryed;
        StartCoroutine("ReInitialize");
    }

    private void updateScore() {
        scoreDisplay.text = currentScore.ToString();
    }
}
