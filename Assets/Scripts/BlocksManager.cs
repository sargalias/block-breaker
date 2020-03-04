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
        block.OnBlockDestroyed += DestroyBlock;
    }

    private void DestroyBlock() {
        numBlocksAlive--;
        if (numBlocksAlive <= 0) {
            OnAllBlocksGone();
        }
    }

    public delegate void AllBlocksGone();
    public event AllBlocksGone OnAllBlocksGone;
}
