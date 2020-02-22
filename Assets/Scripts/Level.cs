using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    private BlocksManager blocksManager;

    void Start() {
        blocksManager = FindObjectOfType<BlocksManager>();
    }
}
