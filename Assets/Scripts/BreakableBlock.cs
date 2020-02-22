using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlock : MonoBehaviour {
    [SerializeField]
    Sprite[] blockSprites;

    private int currentSpriteIdx = 0;
    private SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        currentSpriteIdx += 1;
        if (currentSpriteIdx >= blockSprites.Length) {
            Destroy(gameObject);
            return;
        }
        spriteRenderer.sprite = blockSprites[currentSpriteIdx];
    }
}
