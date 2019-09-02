using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject Gate;
    public float Speed;

    public static bool triggered = false;
    public bool isTriggered = false; // Individual pressure plate trigger (used for AI)
    public GameObject triggerEntity; // The object that is triggering the pressurePlate

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!triggered && Gate.transform.position.y > 2f)
        {
            Debug.Log("should be closing");
            Gate.transform.position += new Vector3(0.0f, -1.0f, 0.0f) * Time.deltaTime * Speed;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        triggered = true;
        isTriggered = true;
        triggerEntity = other.GetComponent<GameObject>();
        this.transform.position += new Vector3(0.0f, -0.04f, 0.0f);
    }

    private void OnTriggerExit(Collider other)
    {
        triggered = false;
        isTriggered = false;
        triggerEntity = null;
        this.transform.position += new Vector3(0.0f, 0.04f, 0.0f);
    }

    /*
        Moves the gate up while a player stands on the pressure plate
    */
    private void OnTriggerStay(Collider other)
    {
        if (Gate.transform.position.y<6.0f)
        {
            Gate.transform.position += new Vector3(0.0f, 1.0f, 0.0f) * Time.deltaTime * Speed;
        }
    }
}
