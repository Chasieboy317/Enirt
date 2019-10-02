using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public GameObject triggeredController;
    public GameObject cameraController;

    void Start()
    {
        triggeredController.SetActive(false);  
    }

    void OnTriggerEnter(Collider other)
    {
        //when one of the players hits the trigger, enable the camera
        if (other.gameObject.tag=="Knight"||other.gameObject.tag=="Robot")
        {
            triggeredController.SetActive(true);
            cameraController.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        //when one of the players leaves the trigger, disable the camera
        if (other.gameObject.tag == "Knight" || other.gameObject.tag == "Robot")
        {
            triggeredController.SetActive(false);
            cameraController.SetActive(true);
        }
    }
}
