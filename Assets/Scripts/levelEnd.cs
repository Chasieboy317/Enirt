using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
       if (playerKnight.position.z < transform.position.z && playerRobot.position.z < transform.position.z) {
           PlayNextLevel();
       }
    }
    //put playNextLevel in script this inherits from
}
