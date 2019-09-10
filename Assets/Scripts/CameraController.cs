using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;
    public float zoom;
    public GameObject[] targets; // List of targets to track
    // Start is called before the first frame update
    void Start()
    {
        /*
         * TO DO:
         * the zoom should be a percentage of the distance between the player and the camera
         * so you should be able to do something like
         * distanceFromPlayer = (camera.x-player.x)*zoom
         */
        //apply the correct amount of zoom
        transform.position += transform.forward * zoom;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: clamp camera X  2>X>18
        transform.position = (targets[0].transform.position+targets[1].transform.position)/2 - new Vector3(8.0f,-4.0f,0.0f);
    }
}
