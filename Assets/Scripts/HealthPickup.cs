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

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("collided");
        Debug.Log(player);
        Debug.Log(other.transform.tag);
        if (!player&&other.transform.tag=="Knight")
        {
            Debug.Log("picked up");
            other.transform.gameObject.GetComponent<Destructable>().SendMessage("takeDamage",(-health));
            Destroy(gameObject);
        }

        else if (!player && other.transform.tag == "Robot")
        {
            Debug.Log("picked up");
            other.transform.gameObject.GetComponent<Destructable>().SendMessage("takeDamage", (-health));
            Destroy(gameObject);
        }
    }
    
}
