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
    public bool fallingBlocksCompleted;
    public Camera fallingBlocksCamera;
    //public float fallingBlocksDelay = 1f;
    //public float fallingBlocksTriggered;

    //climbing puzzle
    public GameObject tallBlock;
    public GameObject tallBlockLever;

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
        fallingBlocksCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * Falling Blocks Puzzle
         */
        if (!fallingBlocksCompleted && fallingBlocksActivateLever.transform.gameObject.GetComponent<lever>().activated)
        {
            CamController.SetActive(false);
            fallingBlocks.SetActive(true);
        }
        else if(fallingBlocksCompleted && fallingBlocksActivateLever.transform.gameObject.GetComponent<lever>().activated)
        {
            CamController.SetActive(true);
            fallingBlocksCamera.enabled = false;
        }
        //check falling blocks puzzle completed
        if(KNIGHT.transform.position.z < -12 && ROBOT.transform.position.z < -12)
        {
            fallingBlocksCompleted = true;
        }

        /*
         * Climbing Puzzle
         */
        if (tallBlockLever.transform.gameObject.GetComponent<lever>().activated)
        {
            Debug.Log("InTallBlockIf");
            tallBlock.transform.gameObject.GetComponent<ascend>().enabled = true;
        }

        /*
         * Final Battle
         * activate level and teleport players there
         */
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
