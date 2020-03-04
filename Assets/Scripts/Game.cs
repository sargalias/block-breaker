﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
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

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();

        level = FindObjectOfType<Level>();
        level.OnLevelWin += HandleLevelWin;
        level.OnBlockDestroyed += HandleBlockDestroyed;

        updateScore();
    }

    private void HandleBlockDestroyed() {
        currentScore += pointsPerBlockDestoryed;
        Debug.Log(currentScore);
    }

    private void HandleLevelWin() {
        sceneLoader.LoadNextScene();
    }

    private void Update() {
        Time.timeScale = gameSpeed;
        updateScore();
    }

    private void updateScore() {
        scoreDisplay.text = currentScore.ToString();
    }
}
