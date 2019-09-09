using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoppelgangerBattle : MonoBehaviour
{
    public PressurePlate ppLeft;
    public PressurePlate ppRight;

    public Transform spawnPointLeft;
    public Transform spawnPointRight;

    public GameObject knightDoppelgangerPrefab;
    public GameObject robotDoppelgangerPrefab;
    public GameObject spawn1;
    public GameObject spawn2;

    public GameObject respawnEffect;
    public float spawnTime;
    public float spawnTimeTotal = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ppLeft.triggered && ppRight.triggered) //spawn doppelgangers
        {
            RaycastHit player;
            if(Physics.Raycast(ppLeft.transform.position, Vector3.up, out player))
            {
                spawn1 = Instantiate(respawnEffect, spawnPointRight.position + new Vector3(0, 1, 0), spawnPointRight.rotation);
                spawn2 = Instantiate(respawnEffect, spawnPointLeft.position + new Vector3(0, 1, 0), spawnPointLeft.rotation);
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
                Destroy(ppLeft);
                Destroy(ppRight);
            }
        }
        if (Time.time - spawnTime > spawnTimeTotal)
        {
            Destroy(spawn1);
            Destroy(spawn2);
        }
    }
}
