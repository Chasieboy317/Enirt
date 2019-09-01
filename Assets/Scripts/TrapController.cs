using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{

    public PressurePlate[] pressurePlates;
    public GameObject Gate;
    public float Speed;
    public float downHeight;
    public float upHeight;

    private bool triggered;

    private void Start()
    {
        triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (PressurePlate pp in pressurePlates)
        {
            if (pp.triggered) { triggered = true; break; }
        }

        if (triggered && Gate.transform.position.y < upHeight)
        {
            Gate.transform.position += new Vector3(0.0f, 0.1f, 0.0f) * Time.deltaTime * Speed;
        }

        if (!triggered && Gate.transform.position.y > downHeight)
        {
            Gate.transform.position += new Vector3(0.0f, -0.1f, 0.0f) * Time.deltaTime * Speed;
        }

        triggered = false;
    }
}
