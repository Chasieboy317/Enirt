using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Manager : MonoBehaviour
{
    public bool gameOver;
    public bool successfulCompletion;

    public GameObject CamController;

    //players
    public GameObject KNIGHT;
    public GameObject ROBOT;

    //Falling blocks Puzzle
    public GameObject fallingBlocksActivateLever;
    public GameObject fallingBlocks;
    //public Camera fallingBlocksCamera;

    //For final battle
    public bool finalBattle;
    public GameObject doppelgangerBattle;
    public Transform finalBattleSpawnLeft;
    public Transform finalBattleSpawnRight;
    public Camera finalBattleCamera;

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
        //fallingBlocks puzzle
        if (fallingBlocksActivateLever.transform.gameObject.GetComponent<lever>().activated)
        {
            CamController.SetActive(false);
            fallingBlocks.SetActive(true);
            //fallingBlocksCamera.enabled = true;
        }

        //when Time for final battle - activate level and teleport players there
        if (finalBattle)
        {
            doppelgangerBattle.SetActive(true);
            //set finalBattleCamera active?
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
