using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/*
    The fighter, or brawler type enemy is your simple "go hit the player" type enemy. They aren't
    Particularly diverse in what they do, but will target players they can get to.
*/
public class fighter : enemy
{
    public Animator animationController;
    public NavMeshAgent agent;
    public float rotationSpeed = 5;
    public float walkRadius = 16f;
    public float runRadius = 10f;

    public float reTarget = 5f;

    public bool targetLocked = false; //TODO: Add patrol route if no player is targeted

    public Transform playerKnight;
    public Transform playerRobot;
    public Transform target;

    /*
        Get components for the AI and animation
    */
    public void OnStart()
    {
        animationController = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Start() {
        playerKnight = playerManager.instance.players[0].transform;
        playerRobot = playerManager.instance.players[1].transform;
        OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }

    public void OnUpdate()
    {
        reTarget -= Time.deltaTime;
        if (targetLocked == false)
        {
            // Find a target.
            // Only lock on if the target is not dead
            // If the target exists, lock on to the closest target
            if (playerKnight == null)
            {
                targetLocked = true;
                target = playerRobot;
            }
            else if (playerRobot == null)
            {
                targetLocked = true;
                target = playerKnight;
            }
            else if (playerKnight == null && playerRobot == null)
            {
                targetLocked = false;
            }
            else if (playerKnight != null && playerRobot != null)
            {
                target = (playerKnight.position - transform.position).magnitude > (playerRobot.position - transform.position).magnitude ? playerRobot : playerKnight;
                targetLocked = true;
            }
        }
        if (targetLocked)
        {
            // Only get a new target after a certain amount of time. (5 seconds)
            if (reTarget <= 0 || target == null)
            {
                reTarget = 5f;
                targetLocked = false;
            }
            // Control various aspects of targeting and animation
            // Only walk if the player is still far
            // Start running if the player is getting close
            // Attack if the player is within reach
            float distance = (target.position - transform.position).magnitude;
            if (distance < walkRadius)
            {
                agent.SetDestination(target.position);
                if (distance > runRadius)
                {
                    animationController.SetBool("walk", true);
                    animationController.SetBool("run", false);
                    animationController.SetBool("attack", false);
                }
                if (distance < runRadius)
                {
                    animationController.SetBool("walk", false);
                    animationController.SetBool("run", true);
                    animationController.SetBool("attack", false);
                }
                if (distance <= 2f)
                {
                    FaceTarget();
                    animationController.SetBool("walk", false);
                    animationController.SetBool("run", false);
                    animationController.SetBool("attack", true);
                }
            }
            else
            {
                animationController.SetBool("walk", false);
                animationController.SetBool("run", false);
                animationController.SetBool("attack", false);
            }
        }
    }

    /*
        Turn the model to face its target
    */
    public void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*rotationSpeed);
    }

    /*
        Draw nice circular indicators in editor to show various stats
    */
    public void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, walkRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,runRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,2f);
    }
}
