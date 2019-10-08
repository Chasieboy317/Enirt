using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is used to enable/disable defined cameras when the either play hits a certain trigger
public class CameraTrigger : MonoBehaviour
{
    public GameObject triggeredController;
    public GameObject cameraController;

    //disable the trigger on start... obviously
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

    void OnTriggerStay(Collider other)
    {
        //when one of the players stays in the trigger, enable the camera
        if (other.gameObject.tag == "Knight" || other.gameObject.tag == "Robot")
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
