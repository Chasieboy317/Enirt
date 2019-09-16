using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/*
    The fighter, or brawler type enemy is your simple "got hit player" type enemy. They aren't
    Particularly diverse in what they do, but will target players they can get to.
*/
public class fighter : enemy
{
    public Animator animationController;
    public NavMeshAgent agent;
    public float rotationSpeed = 5;
    public float walkRadius = 16f;
    public float runRadius = 10f;

    private float reTarget = 5f;

    private bool targetLocked = false; //TODO: Add patrol route if no player is targeted

    private Transform playerKnight;
    private Transform playerRobot;
    public Transform target;

    void Start() {
        playerKnight = playerManager.instance.players[0].transform;
        playerRobot = playerManager.instance.players[1].transform;
        animationController = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        reTarget -= Time.deltaTime;
        if (targetLocked == false) {
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
        if (targetLocked) {
            if (reTarget <= 0) {
                reTarget = 5f;
                targetLocked = false;
            }
            float distance = (target.position - transform.position).magnitude;
            if (distance < walkRadius) {
                agent.SetDestination(target.position);
                if (distance > runRadius) {
                    animationController.SetBool("walk", true);
                    animationController.SetBool("run", false);
                    animationController.SetBool("attack", false);
                }
                if (distance < runRadius) {
                    animationController.SetBool("walk", false);
                    animationController.SetBool("run", true);
                    animationController.SetBool("attack", false);
                }
                if (distance <= 2f) {
                    FaceTarget();
                    animationController.SetBool("walk", false);
                    animationController.SetBool("run", false);
                    animationController.SetBool("attack", true);
                }
            } else {
                animationController.SetBool("walk", false);
                animationController.SetBool("run", false);
                animationController.SetBool("attack", false);
            }
        }
    }

    //void FixedUpdate() {
    //    if (health <= 0) {
    //        Die();
    //    }
    //}

    void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*rotationSpeed);
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, walkRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,runRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,2f);
    }

    //private void OnCollisionEnter(Collision other) {
    //    animationController.SetBool("knockBack",true);
    //}
}
