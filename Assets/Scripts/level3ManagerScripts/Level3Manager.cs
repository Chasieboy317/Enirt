using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Manager : gameEndManager
{
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

    //Window puzzle
    public Transform windowPuzzleCheckpoint;
    public GameObject pressureP1;
    public GameObject pressureP2;

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
        fallingBlocksCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!finalBattle && (KNIGHT==null || ROBOT == null))
        {
            GameOver(false);
        }
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
        if(KNIGHT.transform.position.z < -11 && ROBOT.transform.position.z < -11)
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
         * Window Puzzle
         */

        RaycastHit cylinder;
        if (Physics.Raycast(windowPuzzleCheckpoint.position, Vector3.up, out cylinder))
        {
            if(cylinder.transform.tag == "redCylinder")
            {
                //finalBattle = true; //this is how you get to the final battle for now
                pressureP1.SetActive(true);
                pressureP2.SetActive(true);
            }
        }

        if(pressureP1.transform.gameObject.GetComponent<PressurePlate>().triggered && pressureP2.transform.gameObject.GetComponent<PressurePlate>().triggered)
        {
            finalBattle = true;
        }
        /*
         * Final Battle
         * activate level and teleport players there
         */
        if (finalBattle)
        {
            CamController.SetActive(false);
            //Destroy current players
            Destroy(ROBOT);
            Destroy(KNIGHT);
            doppelgangerBattle.SetActive(true);
            //set finalBattleCamera active?
            /*
            KNIGHT.transform.position = finalBattleSpawnRight.position;
            KNIGHT.transform.rotation = finalBattleSpawnRight.rotation;
            ROBOT.transform.position = finalBattleSpawnLeft.position + new Vector3(0,0.1f,0);
            ROBOT.transform.rotation = finalBattleSpawnLeft.rotation;
            */
        }
        
    }

    
}
