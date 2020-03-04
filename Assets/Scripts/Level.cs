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
        blocksManager.OnBlockDestroyed += HandleBlockDestroyed;
        blocksManager.OnAllBlocksGone += HandleAllBlocksGone;
    }

    private void HandleBlockDestroyed() {
        OnBlockDestroyed();
    }

    private void HandleAllBlocksGone() {
        OnLevelWin();
    }

    public delegate void BlockDestoryed();
    public event BlockDestoryed OnBlockDestroyed;

    public delegate void LevelWin();
    public event LevelWin OnLevelWin;
}
