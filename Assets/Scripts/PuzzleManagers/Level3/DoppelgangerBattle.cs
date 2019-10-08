using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This Script is manages the stages of the final battle - the culmulation of level 3
 * The players are transported to a platform, after triggering pressure plates doppelgangers spawn and shortly after that enemies spawn
 * The platform is divided into a grid by gas forcing the players to move in reverse to use the doppelgnagers to fight the enemies
 * If successful, The gas disappears - a turnstile appears
 * If all the players push the turnstile at once the gem explodes and the players have one
 */
public class DoppelgangerBattle : gameEndManager
{
    //Gem explodes if players complete level
    public GameObject Gem;
    public bool gemExploded = false;
    public GameObject explosion;

    //PressurePlates to trigger spawning Doppelgangers
    public GameObject PPLeft;
    public GameObject PPRight;

    //Doppelgangers and spawn points
    public Transform spawnPointLeft;
    public Transform spawnPointRight;
    public GameObject knightDoppelgangerPrefab;
    public GameObject robotDoppelgangerPrefab;
    public GameObject robotDoppelganger;
    public GameObject knightDoppelganger;
    GameObject spawn1;
    GameObject spawn2;
    public bool spawned;
    public GameObject respawnEffect;
    float spawnTime;
    float spawnTimeTotal = 1.5f;
    //reassign health bars to reflect doppelganger health after spawning them
    public GameObject robotHealth;
    public GameObject knightHealth;

    public GameObject GasEffect;
    
    //enemies
    public GameObject skeletonEnemy;
    public GameObject alienShipEnemy;

    public GameObject turnstile;

    private bool finalStage = false;
    private float finaleStageTime;


    // Start is called before the first frame update
    void Start()
    {
        spawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        //both enemies successfully defeated
        //remove gas and enable turnstile
        if (alienShipEnemy == null && skeletonEnemy == null && !finalStage)
        {
            Debug.Log("skeleton and alienship defeated");
            GasEffect.SetActive(false);
            turnstile.SetActive(true);
            finalStage = true;
        }

        //Pressure plates used to spawn doppelgnagers and scene elements
        if ((PPLeft != null && PPRight != null) && (PPLeft.gameObject.transform.GetComponent<PressurePlate>().triggered && PPRight.gameObject.transform.GetComponent<PressurePlate>().triggered))
        {
            //spawn the doppelgnagers (with spawn effect)
            spawn1 = Instantiate(respawnEffect, spawnPointRight.position + new Vector3(0, 1, 0), spawnPointRight.rotation);
            spawn2 = Instantiate(respawnEffect, spawnPointLeft.position + new Vector3(0, 1, 0), spawnPointLeft.rotation);
            spawned = true;
            spawnTime = Time.time;
            knightDoppelganger = Instantiate(knightDoppelgangerPrefab, spawnPointLeft.position, spawnPointLeft.rotation);
            robotDoppelganger = Instantiate(robotDoppelgangerPrefab, spawnPointRight.position, spawnPointRight.rotation);

            Destroy(PPLeft);
            Destroy(PPRight);

            Gem.SetActive(true);
            GasEffect.SetActive(true);

            //make health bars reference doppelganger health
            robotHealth.GetComponent<HealthBar>().player = robotDoppelganger;
            knightHealth.GetComponent<HealthBar>().player = knightDoppelganger;

        }

        //Destroy spawn effect after spawn time
        if (Time.time - spawnTime > spawnTimeTotal && spawned)
        {
            Destroy(spawn1);
            Destroy(spawn2);
            //After destroying spawn effect, set the enemies active
            if (Time.time > spawnTime + spawnTimeTotal + 2f && !finalStage)
            {
                //set enemies active
                skeletonEnemy.SetActive(true);
                alienShipEnemy.SetActive(true);
            }

        }


        if (finalStage && turnstile.transform.gameObject.GetComponent<Turnstile>().getTurned() && !gemExploded)
        {
            Instantiate(explosion, Gem.transform.position, Gem.transform.rotation);
            gemExploded = true;
            Gem.SetActive(false);
            finaleStageTime = Time.time;
        }

        //successful completion of level
        if(finalStage && gemExploded && Time.time > finaleStageTime + 8f)
        {
            GameOver(true);

        }

        //if either doppelganger dead - GameOver. success=false
        if(spawned && (knightDoppelganger==null || robotDoppelganger == null))
        {
            GameOver(false);
        }

    }

}



