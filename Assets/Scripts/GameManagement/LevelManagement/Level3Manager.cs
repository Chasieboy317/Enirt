using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Manager : gameEndManager
{
    //Standard scene cameras
    public GameObject CamController;

    //players
    public GameObject KNIGHT;
    public GameObject ROBOT;

    //Falling blocks Puzzle
    public GameObject fallingBlocksActivateLever;
    public GameObject fallingBlocks;
    public bool fallingBlocksCompleted;
    public Camera fallingBlocksCamera;

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
            GameOver(false); //either player has dies, GameOver with success = false
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
         * Lever pulled - make block for robot to climb ascend
         */
        if (tallBlockLever.transform.gameObject.GetComponent<lever>().activated)
        {
            tallBlock.transform.gameObject.GetComponent<ascend>().enabled = true;
        }

        /*
         * Window Puzzle
         * Check using RayCast whether the red cylinder has been moved to the correct position to match 
         */

        RaycastHit cylinder;
        if (Physics.Raycast(windowPuzzleCheckpoint.position, Vector3.up, out cylinder))
        {
            if(cylinder.transform.tag == "redCylinder")
            {
                //enable pressure plates when 
                pressureP1.SetActive(true);
                pressureP2.SetActive(true);
            }
        }

        //if both pressure plates are active and triggered, the players have reached the final stage
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
            
        }

        //check death by falling
        if (KNIGHT.transform.position.y < 5)
        {
            Destroy(KNIGHT);
        }
        else if (ROBOT.transform.position.y < 5)
        {
            Destroy(ROBOT);
        }

    }

    
}
