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
    // Start is called before the first frame update
    void Start()
    {
        animController = GetComponent<Animator>();
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag != this.tag && other.transform.gameObject.GetComponent("Destructable"))
        {
            other.transform.gameObject.SendMessage("takeDamage", damage);
        }
    }
}
