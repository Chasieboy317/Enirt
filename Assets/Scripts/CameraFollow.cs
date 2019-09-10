using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    private Vector2 lastPos;
    private Vector2 deltaPos;
    void Start()
    {
        //transform.position.z = player.transform.position.z;
        lastPos = new Vector2(player.transform.position.y, player.transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        deltaPos = new Vector2(player.transform.position.y - lastPos.x, player.transform.position.z - lastPos.y);
        transform.position += new Vector3(0.0f, deltaPos.x, deltaPos.y);
        lastPos = new Vector2(player.transform.position.y, player.transform.position.z);
    }
}
