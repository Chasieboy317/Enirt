using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{

    public GameObject[] pressurePlates;
    public GameObject Gate; // Default to self
    public float Speed = 5; // Speed at which trap opens
    public float upHeight = 5; // How far the trap moves from default position
    public int triggersNeeded = 1; // How many pressureplates/levers neet to be pulled for this to activate

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
        int triggers = 0;
        foreach (GameObject triggerable in pressurePlates) //check if any of the pressure plates are triggered
        {
            Debug.Log(triggerable.GetComponent<lever>());
            if (triggerable.GetComponent<PressurePlate>()){
                if (triggerable.GetComponent<PressurePlate>().triggered){
                    triggers++;
                }
            }
            if (triggerable.GetComponent<lever>()){
                if (triggerable.GetComponent<lever>().activated) {
                    triggers++;
                }
            }
            if (triggers >= triggersNeeded) { triggered = true; }
        }

        if (triggered && currentPos < upHeight + startPos) //if the trap is triggered and the trap is lower than the specified height, move it up
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
