using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    private BlocksManager blocksManager;
    private SceneLoader sceneLoader;

    private void Start() {
        sceneLoader = FindObjectOfType<SceneLoader>();
        SetupBlocksEvents();
    }

    private void SetupBlocksEvents() {
        blocksManager = FindObjectOfType<BlocksManager>();
        blocksManager.OnAllBlocksGone += Win;
    }

    private void Win() {
        sceneLoader.LoadNextScene();
    }
}
