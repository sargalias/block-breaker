using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksManager : MonoBehaviour {
    private int numBlocksAlive = 0;

    private void Start() {
        Block[] blocks = FindObjectsOfType<Block>();
        Array.ForEach(blocks, WatchBlock);
        numBlocksAlive = blocks.Length;
    }

    private void WatchBlock(Block block) {
        block.OnBlockDestroyed += HandleBlockDestroyed;
    }

    private void HandleBlockDestroyed() {
        OnBlockDestroyed();

        numBlocksAlive--;
        if (numBlocksAlive <= 0) {
            OnAllBlocksGone();
        }
    }

    public delegate void BlockDestroyed();
    public event BlockDestroyed OnBlockDestroyed;

    public delegate void AllBlocksGone();
    public event AllBlocksGone OnAllBlocksGone;
}
