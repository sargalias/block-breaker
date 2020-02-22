﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryBottom : MonoBehaviour {
    [SerializeField]
    SceneLoader sceneLoader;

    void OnTriggerEnter2D(Collider2D collision) {
        sceneLoader.LoadGameOverScene();
    }
}
