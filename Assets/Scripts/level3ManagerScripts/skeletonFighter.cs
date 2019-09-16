using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonFighter : fighter 
{
    GameObject[] objects;
    GameObject TARGET;
    //private LockTarget lockTargetScript;
    public void OnStart()
    {
        playerKnight = getTarget("Robot","RobotDoppelganger").transform;
        playerRobot = getTarget("Knight", "KnightDoppelganger").transform;
    }
    public GameObject getTarget(string tag, string script)
    {
        objects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject o in objects)
        {
            if (o.transform.gameObject.GetComponent(script) != null)
            {
                TARGET = o;
            }
        }
        return TARGET;
    }
}
