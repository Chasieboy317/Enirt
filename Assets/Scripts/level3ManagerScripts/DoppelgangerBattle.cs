﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoppelgangerBattle : MonoBehaviour
{
    public GameObject Gem;
    public bool gemExploded = false;
    public GameObject explosion;

    PressurePlate ppLeft;
    PressurePlate ppRight;

    public GameObject PPLeft;
    public GameObject PPRight;

    public Transform spawnPointLeft;
    public Transform spawnPointRight;

    public GameObject knightDoppelgangerPrefab;
    public GameObject robotDoppelgangerPrefab;
    GameObject spawn1;
    GameObject spawn2;
    public bool spawned;

    public GameObject GasEffect;

    public GameObject respawnEffect;
    float spawnTime;
    float spawnTimeTotal = 1.5f;

    //enemies
    public GameObject skeletonEnemy;
    public GameObject alienShipEnemy;

    public GameObject turnstile;

    private bool finalStage = false;

    // Start is called before the first frame update
    void Start()
    {
        ppLeft = (PressurePlate) PPLeft.transform.gameObject.GetComponent("PressurePlate");
        ppRight = (PressurePlate)PPRight.transform.gameObject.GetComponent("PressurePlate");
        spawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(alienShipEnemy == null && skeletonEnemy == null);
        //both enemies successfully defeated
        if (alienShipEnemy == null && skeletonEnemy == null && !finalStage)
        {
            GasEffect.SetActive(false);
            turnstile.SetActive(true);
            finalStage = true;
        }

        //Pressure plates used to spawn scene elements
        if (PPLeft != null && PPRight != null)
        {
            if (ppLeft.triggered && ppRight.triggered) //spawn doppelgangers
            {
                RaycastHit player;
                if (Physics.Raycast(ppLeft.transform.position, Vector3.up, out player))
                {
                    spawn1 = Instantiate(respawnEffect, spawnPointRight.position + new Vector3(0, 1, 0), spawnPointRight.rotation);
                    spawn2 = Instantiate(respawnEffect, spawnPointLeft.position + new Vector3(0, 1, 0), spawnPointLeft.rotation);
                    spawned = true;
                    spawnTime = Time.time;

                    if (player.transform.tag == "Knight")
                    {
                        Instantiate(knightDoppelgangerPrefab, spawnPointRight.position, spawnPointRight.rotation);
                        Instantiate(robotDoppelgangerPrefab, spawnPointLeft.position, spawnPointLeft.rotation);
                    }
                    else
                    {
                        Instantiate(robotDoppelgangerPrefab, spawnPointRight.position, spawnPointRight.rotation);
                        Instantiate(knightDoppelgangerPrefab, spawnPointLeft.position, spawnPointLeft.rotation);
                    }
                    Destroy(PPLeft);
                    Destroy(PPRight);

                    Gem.SetActive(true);
                    GasEffect.SetActive(true);

                }
            }
        }
        
        if (Time.time - spawnTime > spawnTimeTotal && spawned)
        {
            Debug.Log("should destroy spawn effect");
            Destroy(spawn1);
            Destroy(spawn2);

            if(Time.time > spawnTime + spawnTimeTotal + 2f && !finalStage)
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
        }
    }
}
