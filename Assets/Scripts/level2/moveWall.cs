using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Set wall to activing, moving it into position
Used for puzzle 3 in level 2
*/
public class moveWall : MonoBehaviour
{
    public bool enabled; // Is the wall alowed to move yet
    public float moveSpeed = 1f; // Speed at which wall opens
    public float openSize = 10f; // Offset from starting pos that is considered open
    public puzzleController puzzle; // Let the puzzle know its ready

    public moveDirection direction; // Direction the wall will open in
    private bool open;
    
    // Possible directions for the wall to move
    public enum moveDirection {
        UP,
        DOWN
    };

    private float startingPos;
    // Start is called before the first frame update
    void Start()
    {
        enabled = false;
        open = false;
        startingPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (enabled) {
            move();
        }
    }

    // Moves the wall into position based on its movement direction
    public void move() {
        if (direction == moveDirection.UP) {
            if (transform.position.y < startingPos + openSize) {
                transform.position += new Vector3(0.0f,1.0f,0.0f) * Time.deltaTime * moveSpeed;
            }
            else {
                open = true;
            }
        }
        if (direction == moveDirection.DOWN) {
            if (transform.position.y > startingPos - openSize) {
                transform.position -= new Vector3(0.0f,1.0f,0.0f) * Time.deltaTime * moveSpeed;
            }
            else {
                open = true;
            }
        }
        if (open && puzzle) {
            puzzle.puzzleReady = true;
        }
    }

    // Enable the wall for movement
    public void enable() {
        enabled = true;
    }
}
