using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public bool player; //this value will determine whether the knight or the robot can use the pickup. true is for robot, false for knight
    public int health;
    public float rotationSpeed;

    void Start()
    {
        player = false;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f) * rotationSpeed * Time.deltaTime, Space.Self);
    }

    public void onCollisionEnter(Collider other)
    {
        Debug.Log("collided");
        if (!player&&other.gameObject.tag=="Knight")
        {
            Debug.Log("picked up");
            other.gameObject.GetComponent<Destructable>().takeDamage(-health);
            Destroy(gameObject);
        }

        else if (player && other.gameObject.tag == "Robot")
        {
            Debug.Log("picked up");
            other.gameObject.GetComponent<Destructable>().takeDamage(-health);
            Destroy(gameObject);
        }
    }
}
