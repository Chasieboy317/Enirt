using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float speed;
    public GameObject player;

    private float deltazPos;
    private float lastzPos;

    //private float deltayPos;
    //private float lastyPos;
    void Start()
    {
        lastzPos = player.transform.position.z;
        //lastyPos = player.transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        deltazPos = player.transform.position.z - lastzPos;
        //deltayPos = player.transform.position.y - lastyPos;
        transform.position += new Vector3(0.0f, 0.0f, deltazPos);
        lastzPos = transform.position.z;
        //lastyPos = transform.position.z;
    }
}
