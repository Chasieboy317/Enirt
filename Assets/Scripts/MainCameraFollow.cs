using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraFollow : MonoBehaviour
{
    private GameObject robot;
    private GameObject knight;

    private Vector2 lastPos;
    private Vector2 deltaPos;
    // Start is called before the first frame update
    void Start()
    {
        robot = GameObject.FindWithTag("Robot");
        knight = GameObject.FindWithTag("Knight");

        lastPos = new Vector2((robot.transform.position.y+knight.transform.position.y)/2,
                                (robot.transform.position.z + knight.transform.position.z)/2);
    }

    // Update is called once per frame
    void Update()
    {
        deltaPos = new Vector2((robot.transform.position.y + knight.transform.position.y) / 2 - lastPos.x,
                                (robot.transform.position.z + knight.transform.position.z) / 2 - lastPos.y);
        transform.position += new Vector3(0.0f, deltaPos.x, deltaPos.y);
        lastPos = new Vector2((robot.transform.position.y + knight.transform.position.y) / 2,
                                (robot.transform.position.z + knight.transform.position.z) / 2);
    }
}
