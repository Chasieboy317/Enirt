using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoppelgangerBattle : MonoBehaviour
{
    public GameObject Gem;

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

    public GameObject GasEffect;

    public GameObject respawnEffect;
    float spawnTime;
    float spawnTimeTotal = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        ppLeft = (PressurePlate) PPLeft.transform.gameObject.GetComponent("PressurePlate");
        ppRight = (PressurePlate)PPRight.transform.gameObject.GetComponent("PressurePlate");
    }

    // Update is called once per frame
    void Update()
    {
        //Pressure plates used to spawn scene elements
        if(PPLeft !=null && PPRight != null)
        {
            if (ppLeft.triggered && ppRight.triggered) //spawn doppelgangers
            {
                RaycastHit player;
                if (Physics.Raycast(ppLeft.transform.position, Vector3.up, out player))
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
                    Destroy(PPLeft);
                    Destroy(PPRight);

                    Gem.SetActive(true);
                    GasEffect.SetActive(true);
                }
            }
        }
        
        if (Time.time - spawnTime > spawnTimeTotal)
        {
            Debug.Log("should destroy spawn effect");
            Destroy(spawn1);
            Destroy(spawn2);
        }
    }
}
