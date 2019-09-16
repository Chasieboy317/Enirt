using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public GameObject triggeredController;
    public GameObject cameraController;
    // Start is called before the first frame update
    void Start()
    {
        triggeredController.SetActive(false);  
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Knight"||other.gameObject.tag=="Robot")
        {
            triggeredController.SetActive(true);
            cameraController.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Knight" || other.gameObject.tag == "Robot")
        {
            triggeredController.SetActive(false);
            cameraController.SetActive(true);
        }
    }
}
