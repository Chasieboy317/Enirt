using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Manager : MonoBehaviour
{
    public bool gameOver;
    public bool successfulCompletion;

    //players
    public GameObject KNIGHT;
    public GameObject ROBOT;

    //For final battle
    public bool finalBattle;
    public GameObject doppelgangerBattle;
    public Transform finalBattleSpawnLeft;
    public Transform finalBattleSpawnRight;

    //start timer?
    //win/lose conditions

    void Start()
    {
        finalBattle = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        //when Time for final battle - activate level and teleport players there
        if (finalBattle)
        {
            doppelgangerBattle.SetActive(true);
            KNIGHT.transform.position = finalBattleSpawnLeft.position;
            KNIGHT.transform.rotation = finalBattleSpawnLeft.rotation;
            ROBOT.transform.position = finalBattleSpawnRight.position;
            ROBOT.transform.rotation = finalBattleSpawnRight.rotation;
        }
        

        if (gameOver)
        {
            //end game //check win or loose
            Debug.Log("GameOver");
        }
    }

    public void GameOver(bool success)
    {
        gameOver = true;
        successfulCompletion = success;

        Debug.Log("GameOver" + success);
    }
}
