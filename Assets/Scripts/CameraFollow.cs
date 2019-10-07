using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is used to follow the player that is defined
public class CameraFollow : MonoBehaviour
{

    public GameObject player; //the player to follow
    public Vector3 offset = new Vector3(0, 1.5f, 0); //the offset to add to the camera position, pre-defined


    //set the position of the camera to the player + whatever offset has been given
    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.transform.position.y, player.transform.position.z) + offset;
    }
}
