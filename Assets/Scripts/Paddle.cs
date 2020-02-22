using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    [SerializeField]
    private float worldUnits;

    void Update() {
        float x = Input.mousePosition.x / Screen.width * worldUnits;
        x = Mathf.Clamp(x, 1, 15);
        Vector2 newPosition = new Vector2(x, transform.position.y);
        transform.position = newPosition;
        if (Moved != null) {
            Moved(newPosition);
        }
    }

    public delegate void MovedEventHandler(Vector2 position);
    public event MovedEventHandler Moved;
}
