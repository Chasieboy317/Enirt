using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWall : MonoBehaviour
{
    public bool enabled; // Is the wall alowed to move yet
    public float moveSpeed = 1f; // Speed at which wall opens
    public float openSize = 10f; // Offset from starting pos that is considered open

    public moveDirection direction; // Direction the wall will open in
    
    public enum moveDirection {
        UP,
        DOWN
    };

    private float startingPos;
    // Start is called before the first frame update
    void Start()
    {
        enabled = false;
        startingPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (enabled) {
            move();
        }
    }

    public void move() {
        if (direction == moveDirection.UP) {
            if (transform.position.y < startingPos + openSize) {
                transform.position += new Vector3(0.0f,1.0f,0.0f) * Time.deltaTime * moveSpeed;
            }
        }
        if (direction == moveDirection.DOWN) {
            if (transform.position.y > startingPos - openSize) {
                transform.position -= new Vector3(0.0f,1.0f,0.0f) * Time.deltaTime * moveSpeed;
            }
        }
    }

    public void enable() {
        enabled = true;
    }
}
