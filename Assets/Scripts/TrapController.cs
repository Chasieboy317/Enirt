using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is used to control all pressure plate activated traps/puzzles
//input is received from the pressure plates, and output is given to the object that must be moved
public class TrapController : MonoBehaviour
{

    public GameObject[] pressurePlates; //all the pressure plates that can/must be activated for the puzzle to be solved
    public GameObject Gate; //the object that should be moved when a/any pressure plates are triggered
    public float Speed = 5; // Speed at which trap opens
    public float upHeight = 5; // How far the trap moves from default position
    public int triggersNeeded = 1; // How many pressureplates/levers neet to be pulled for this to activate

    private float startPos; //the initial position of the object
    private float currentPos; //the current position of the object
    private bool triggered; //boolean used to check whether the object should be moving
    private AudioSource openingSource;

    private void Start()
    {
        triggered = false; //this value refers to whether any one of the pressure plates connecting to the controller are triggered
        startPos = Gate.transform.position.y; //this is the initial "down" position of the trap
        openingSource = GetComponent<AudioSource>();
    }

    //check whether any of the pressure plates are triggered and move the object accordingly
    void Update()
    {
        currentPos = Gate.transform.transform.position.y;
        int triggers = 0;
        foreach (GameObject triggerable in pressurePlates) //check if any of the pressure plates are triggered
        {
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
            if (openingSource) {
                if (!openingSource.isPlaying) { openingSource.Play(); }
            }
            Gate.transform.position += new Vector3(0.0f, 0.1f, 0.0f) * Time.deltaTime * Speed;
            
        }

        if (!triggered && currentPos > startPos) //if the trap is not triggered and the trap is higher than the start position of the trap, move it down
        {
            if (openingSource) {
                if (!openingSource.isPlaying) { openingSource.Play(); }
            }
            Gate.transform.position += new Vector3(0.0f, -0.1f, 0.0f) * Time.deltaTime * Speed;
        }


        triggered = false;
    }
}
