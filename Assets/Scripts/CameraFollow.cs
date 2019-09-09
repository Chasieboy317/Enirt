using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float speed;
    public GameObject player;

    private float deltaPos;
    private float lastPos;
    void Start()
    {
        lastPos = player.transform.position.z;
    }
    // Update is called once per frame
    void Update()
    {
        deltaPos = player.transform.position.z - lastPos;
        //Debug.Log("Delta is now: " + deltaPos);
        transform.position += new Vector3(0.0f, 0.0f, deltaPos);
        lastPos = transform.position.z;
    }
}
