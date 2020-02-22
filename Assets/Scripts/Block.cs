using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    [SerializeField]
    Sprite[] blockSprites;

    private int currentSpriteIdx = 0;
    private SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        gameObject.SendMessageUpwards("AddBlock", null, SendMessageOptions.RequireReceiver);
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (currentSpriteIdx < blockSprites.Length - 1) {
            TransitionToNextState();
        }
        else {
            CleanupBlock();
        }
    }

    private void TransitionToNextState() {
        currentSpriteIdx += 1;
        spriteRenderer.sprite = blockSprites[currentSpriteIdx];
    }

    private void CleanupBlock() {
        Destroy(gameObject);
        gameObject.SendMessageUpwards("DestroyBlock", null, SendMessageOptions.RequireReceiver);
    }
}
