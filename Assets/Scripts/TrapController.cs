using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{

    public PressurePlate[] pressurePlates;
    public GameObject Gate;
    public float Speed;
    public float upHeight;
    private float startPos;
    private float currentPos;

    private bool triggered;

    private void Start()
    {
        triggered = false; //this value refers to whether any one of the pressure plates connecting to the controller are triggered
        startPos = Gate.transform.position.y; //this is the initial "down" position of the trap
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = Gate.transform.transform.position.y;
        foreach (PressurePlate pp in pressurePlates) //check if any of the pressure plates are triggered
        {
            if (pp.triggered) { triggered = true; break; }
        }

        if (triggered && currentPos < upHeight) //if the trap is triggered and the trap is lower than the specified height, move it up
        {
            Gate.transform.position += new Vector3(0.0f, 0.1f, 0.0f) * Time.deltaTime * Speed;
        }

        if (!triggered && currentPos > startPos) //if the trap is not triggered and the trap is higher than the start position of the trap, move it down
        {
            Gate.transform.position += new Vector3(0.0f, -0.1f, 0.0f) * Time.deltaTime * Speed;
        }

        triggered = false;
    }
}
