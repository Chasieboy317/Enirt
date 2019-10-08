using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public bool player; //this value will determine whether the knight or the robot can use the pickup. true is for robot, false for knight
    public int health;
    public float rotationSpeed;


    public AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    //rotate the object every update
    void Update()
    {
        transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f) * rotationSpeed * Time.deltaTime, Space.Self);
    }

    //when a player collides with the pickup:
    //play the sound it should make
    //update the players health to full
    //destroy the pickup
    public void OnCollisionEnter(Collision other)
    {
        if (!player&&other.transform.tag=="Knight")
        {
            if (audioSource != null) { audioSource.Play(); }
            other.transform.gameObject.GetComponent<Destructable>().SendMessage("takeDamage",(-health));
            Destroy(gameObject);
        }

        else if (player && other.transform.tag == "Robot")
        {
            if (audioSource != null) { audioSource.Play(); }
            other.transform.gameObject.GetComponent<Destructable>().SendMessage("takeDamage", (-health));
            Destroy(gameObject);
        }
    }
    
}
