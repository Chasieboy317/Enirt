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
<<<<<<< HEAD
=======
        //Debug.Log("Delta is now: " + deltaPos);
>>>>>>> bbb1ff6886689eaf43adc187c942b8c9ac99c1d7
        transform.position += new Vector3(0.0f, 0.0f, deltaPos);
        lastPos = transform.position.z;
    }
}
