using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovementController : MonoBehaviour
{
    public Animator animController;
    public float walkSpeed = 0.4f;
    public float runSpeed = 1.3f;

    public float damage = 1f;

    public float knockBackDistance = 2f;
    private bool knockBack = false;
    private float knockBackTime = 0f;
    private float knockBackTotalTime = 2.10f;

    public GameObject swordCollider;

    private float startAttack;
    private float attackTime = 0.9f;

    // Start is called before the first frame update
    void Start()
    {
        animController = GetComponent<Animator>();

        swordCollider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (animController.GetBool("walk") && !animController.GetBool("run"))
        {
            this.transform.position += transform.forward * walkSpeed * Time.deltaTime;
        }
        if (animController.GetBool("run"))
        {
            this.transform.position += transform.forward * runSpeed * Time.deltaTime;
        }
        if (animController.GetBool("knockBack") && !knockBack)
        {
            knockBack = true;
            animController.SetBool("walk", false);
            animController.SetBool("run", false);
            knockBackTime = Time.time;
            
        }
        if(knockBack && Time.time > knockBackTime + knockBackTotalTime)
        {
            knockBack = false;
            this.transform.position -= transform.forward * knockBackDistance;
        }

        //activate sword collider on attack
        if (animController.GetBool("attack"))
        {
            startAttack = Time.time;
            swordCollider.SetActive(true);
        }
        else if (Time.time > startAttack + attackTime)
        {
            swordCollider.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag != this.tag && other.transform.gameObject.GetComponent("Destructable") && other.transform.gameObject.GetComponent<Destructable>().enabled)
        {
            other.transform.gameObject.SendMessage("takeDamage", damage);
        }
    }
}
