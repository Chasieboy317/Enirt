using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Aesthetics script that opens a door as soon as the game starts
*/
public class openGate : MonoBehaviour
{
    public GameObject door; // Door that will open at start of the game
    public float openPos = 9.0f; // How much the door should open
    public float openSpeed = 1f; // How fast

    // Sound effect for opening door
    public AudioSource sfx;

    private float startingPos;

    void Start() {
        startingPos = door.transform.position.y;
        sfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // If not fully open, open more
        if (door.transform.position.y < startingPos + openPos) {
            if (sfx) {
                if (!sfx.isPlaying) {sfx.Play();}
            }
            door.transform.position += new Vector3(0.0f,1.0f,0.0f) * Time.deltaTime * openSpeed;
        }
    }
}
