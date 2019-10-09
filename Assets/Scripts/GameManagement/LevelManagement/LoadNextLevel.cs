using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Players progress to certain level when they move through a trigger collider in a certain region
public class LoadNextLevel : MonoBehaviour
{
    public int level;

    private bool readyKnight;
    private bool readyRobot;

    void Start()
    {
        readyKnight = false;
        readyRobot = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Knight")
        {
            readyKnight = true;
        }
        else if (other.gameObject.tag == "Robot")
        {
            readyRobot = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (readyKnight&&readyRobot)
        {
            SceneManager.LoadScene(level);
        }
    }
}
