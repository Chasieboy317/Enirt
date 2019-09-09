﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool triggered;
    public float downHeight;

    void Start()

    {
        triggered = false; //this value refers to whether only a single pressure plate is triggered
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!triggered)
        {
            triggered = true;
            this.transform.position += new Vector3(0.0f, -downHeight, 0.0f); //move the pressure plate down to reflect the change
        }
        //Debug.Log("OnTriggerEnter " + triggered);
    }

    private void OnTriggerExit(Collider other)
    {
        if (triggered)
        {
            triggered = false;
            this.transform.position += new Vector3(0.0f, downHeight, 0.0f); //move the pressure plate back up
        }
        //Debug.Log("OnTriggerExit " + triggered);
    }
}
