using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Inherits from 'fighter' which itself inherits from 'enemy'
//for use in Scene 3
//functionally the same as fighter - just targets the KnightDoppelganger
public class skeletonFighter : fighter
{
    
    public GameObject lockTargetObject;
    public static LockTarget lockTargetScript;

    public void Start()
    {
        OnStart();
        lockTargetScript = lockTargetObject.GetComponent<LockTarget>();
        playerKnight = lockTargetScript.getTarget("Knight","KnightDoppelgangerController").transform;
        playerRobot = lockTargetScript.getTarget("Robot", "RobotDoppelgangerController").transform;
    }

    public void Update()
    {
        OnUpdate();
    }

}
