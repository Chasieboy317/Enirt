using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraFollow : MonoBehaviour
{
    public Vector3 offset;
    private GameObject robot;
    private GameObject knight;

    void Start()
    {
        robot = GameObject.FindWithTag("Robot");
        knight = GameObject.FindWithTag("Knight");
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, (robot.transform.position.y + knight.transform.position.y) / 2,
            (robot.transform.position.z + knight.transform.position.z) / 2) + offset;
    }
}
