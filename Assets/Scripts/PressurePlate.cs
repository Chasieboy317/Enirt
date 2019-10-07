using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool triggered; //boolean that will be used to in the trap controller class to provide the correct transformation when the pressure plate is triggeered
    public GameObject triggerEntity; // Object that is triggering the pressure plate e.g. player
    public float downHeight = 0.1f; // How far a pressureplate sinks when activated

    public AudioSource audioSource;

    void Start()

    {
        triggered = false; //this value refers to whether only a single pressure plate is triggered
        audioSource = GetComponent<AudioSource>();
    }

    //primary method for testing whether a player triggered the pressure plate, as well as which player.
    private void OnTriggerEnter(Collider other)
    {
        triggerEntity = other.gameObject; // Set the object which is triggering the pressureplate
        if (!triggered)
        {
            audioSource.Play();
            triggered = true;
            this.transform.position += new Vector3(0.0f, -downHeight, 0.0f); //move the pressure plate down to reflect the change
            Debug.Log("OnTriggerEnter " + triggered);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        audioSource.Play();
        triggered = false;
        triggerEntity = null;
        this.transform.position += new Vector3(0.0f, downHeight, 0.0f); //move the pressure plate back up
        Debug.Log("OnTriggerExit " + triggered);
    }
}
