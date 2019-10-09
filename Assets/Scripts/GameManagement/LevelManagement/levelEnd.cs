using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
Controls the end of the level
Inherits functionality from gameEndManager script
*/
public class levelEnd : gameEndManager
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
        // Load next level when both players cross the final threshhold
       if (playerKnight.position.z < transform.position.z && playerRobot.position.z < transform.position.z) {
           PlayNextLevel();
       }
    }
}
