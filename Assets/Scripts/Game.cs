using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [Range(0.1f, 10f)]
    [SerializeField]
    private float gameSpeed = 1f;
    private Level level;
    private SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();

        level = FindObjectOfType<Level>();
        level.OnLevelWin += HandleLevelWin;
    }

    private void HandleLevelWin() {
        sceneLoader.LoadNextScene();
    }

    private void Update() {
        Time.timeScale = gameSpeed;
    }
}
