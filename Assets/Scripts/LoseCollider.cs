using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryBottom : MonoBehaviour {
    private SceneLoader sceneLoader;

    private void Start() {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        sceneLoader.LoadGameOverScene();
    }
}
