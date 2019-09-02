using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool triggered;

    void Start()

    {
        triggered = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        triggered = true;
        this.transform.position += new Vector3(0.0f, -0.04f, 0.0f);
    }

    private void OnTriggerExit(Collider other)
    {
        triggered = false;
        this.transform.position += new Vector3(0.0f, 0.04f, 0.0f);
    }
}
