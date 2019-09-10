using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openGate : MonoBehaviour
{
    public GameObject door; // Door that will open at start of the game
    public float openPos = 9.0f;
    public float openSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        if (door.transform.position.y < openPos) {
            door.transform.position += new Vector3(0.0f,1.0f,0.0f) * Time.deltaTime * openSpeed;
        }
    }
}
