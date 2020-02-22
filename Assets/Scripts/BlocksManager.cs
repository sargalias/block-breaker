using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksManager : MonoBehaviour {
    private int numBlocksAlive = 0;

    public void AddBlock() {
        numBlocksAlive++;
        Debug.Log(numBlocksAlive);
    }

    public void DestroyBlock() {
        numBlocksAlive--;
        Debug.Log(numBlocksAlive);
    }
}
