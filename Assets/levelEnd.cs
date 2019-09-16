using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelEnd : MonoBehaviour
{
    private Transform playerKnight;
    private Transform playerRobot;

    void Start()
    {
        playerKnight = playerManager.instance.players[0].transform;
        playerRobot = playerManager.instance.players[1].transform;
    }

    // Update is called once per frame
    void Update()
    {
       if (playerKnight.position.z < transform.position.z && playerRobot.position.z < transform.position.z) {
           PlayNextLevel();
       }
    }

    public void PlayNextLevel() {
        if (SceneManager.GetActiveScene().buildIndex == 3) {
            SceneManager.LoadScene(0); // Return to main menu
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
