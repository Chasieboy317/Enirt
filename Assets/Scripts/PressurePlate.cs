using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool triggered;
    public GameObject triggerEntity; // Object that is triggering the pressure plate e.g. player
    public float downHeight = 0.1f; // How far a pressureplate sinks when activated

    void Start()

    {
        triggered = false; //this value refers to whether only a single pressure plate is triggered
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerEntity = other.gameObject; // Set the object which is triggering the pressureplate
        triggered = true;
        this.transform.position += new Vector3(0.0f, -downHeight, 0.0f); //move the pressure plate down to reflect the change
        Debug.Log("OnTriggerEnter " + triggered);
    }

    private void OnTriggerExit(Collider other)
    {
        triggered = false;
        triggerEntity = null;
        this.transform.position += new Vector3(0.0f, downHeight, 0.0f); //move the pressure plate back up
        Debug.Log("OnTriggerExit " + triggered);
    }
}
