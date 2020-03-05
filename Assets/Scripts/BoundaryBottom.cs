using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryBottom : MonoBehaviour {
    [SerializeField]
    private SceneLoader sceneLoader;

    [SerializeField]
    private GameObject game;

    void OnTriggerEnter2D(Collider2D collision) {
        Destroy(game);
        sceneLoader.LoadGameOverScene();
    }
}
