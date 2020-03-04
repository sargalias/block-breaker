using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    private BlocksManager blocksManager;

    private void Start() {
        SetupBlocksEvents();
    }

    private void SetupBlocksEvents() {
        blocksManager = FindObjectOfType<BlocksManager>();
        blocksManager.OnAllBlocksGone += HandleAllBlocksGone;
    }

    private void HandleAllBlocksGone() {
        OnLevelWin();
    }

    public delegate void LevelWin();
    public event LevelWin OnLevelWin;
}
