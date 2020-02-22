using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksManager : MonoBehaviour {
    private int numBlocksAlive = 0;

    public void AddBlock() {
        numBlocksAlive++;
    }

    public void DestroyBlock() {
        numBlocksAlive--;
        if (numBlocksAlive <= 0) {
            OnAllBlocksGone();
        }
    }

    public delegate void AllBlocksGone();
    public event AllBlocksGone OnAllBlocksGone;
}
