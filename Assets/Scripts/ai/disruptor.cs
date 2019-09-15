using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/*
    Disruptor type enemies try their best to prevent players from completing puzzles. 
    They are retarded however, and will lock on to the first player to be on a puzzle piece.
    If no players are on a puzzle piece anymore, they target the closes player.
*/
public class disruptor : enemy
{
    public NavMeshAgent agent;
    public float rotationSpeed = 5f;
    private bool targetLocked = false; // Acquire the first person to step on a pressure plate, and don't switch (These AI are retarded)
    private bool noneTriggered = true; // Check if no more pressure plates are triggered
    private Rigidbody myRB;

    public List<PressurePlate> plates;
    private float reTarget = 2f;

    private Transform playerKnight;
    private Transform playerRobot;
    public Transform target;

    void Start() {
        playerKnight = playerManager.instance.players[0].transform;
        playerRobot = playerManager.instance.players[1].transform;

        foreach (PressurePlate p in disruptorTargetManager.instance.plates) {
            plates.Add(p);
        }

        agent = GetComponent<NavMeshAgent>();
        myRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        reTarget -= Time.deltaTime;
        if (reTarget <= 0) {
            reTarget = 2f;
            targetLocked = false;
        }
        foreach (PressurePlate pressurePlate in plates) {
            noneTriggered = true;
            if (pressurePlate.triggered) {
                noneTriggered = false;
                targetLocked = true;
                target = pressurePlate.triggerEntity.transform;
                break;
            }
        }

       if (noneTriggered) {
           targetLocked = false;  // Allow new target acquisition, without stopping pursuit of current target
       }

       if (!targetLocked) {
            if (playerKnight == null) {
                targetLocked = true;
                target = playerRobot;
            }
            else if (playerRobot == null) {
                targetLocked = true;
                target = playerKnight;
            } 
            else if (playerKnight == null && playerRobot == null) {
                targetLocked = false;
            } else if (playerKnight != null && playerRobot != null){
                target = (playerKnight.position - transform.position).magnitude > (playerRobot.position - transform.position).magnitude ? playerRobot : playerKnight;
                targetLocked = true;
            }
       }

    }

    void FixedUpdate() {
        float distance = (target.position - transform.position).magnitude;
        FaceTarget();
        agent.SetDestination(target.position);
        //myRB.AddForce(myRB.transform.forward * speed);
    }
    
    void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*rotationSpeed);
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("COLLISION");
        myRB.AddForce(myRB.transform.forward * -50 * speed);
    }
}
