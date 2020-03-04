using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
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
}
