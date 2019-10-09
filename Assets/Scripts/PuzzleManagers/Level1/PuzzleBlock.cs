using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is used to move lever-controlled gameobjects
public class PuzzleBlock : MonoBehaviour
{
    public float open; //how much the block should be moved
    public float speed; //how fast the block moves

    public bool activated; //boolean to check whether the block should move on the next update() call
    private bool deadly; //boolean to check if the block is deadly, true if the block is falling, false if it is rising
    private float startPos; //the initial position of the block
    private AudioSource smashSource; //the sound the block will make when it hits the ground

    //initialize all variables
    void Start()
    {
        deadly = false;
        activated = false;
        startPos = transform.position.y;
        smashSource = GetComponent<AudioSource>();
    }

    //move the door every update
    void Update()
    {
        move();
    }

    void move()
    {
        //move the block upwards, set deadly to false
        if (activated && transform.position.y < startPos + open)
        {
            transform.position += new Vector3(0.0f, 0.1f, 0.0f) * Time.deltaTime * speed;
            deadly = false;
        }
        //move the block downwards, set deadly to true
        else if (!activated && transform.position.y > startPos)
        {
            transform.position += new Vector3(0.0f, -0.1f, 0.0f) * Time.deltaTime * speed;
            deadly = true;
            if (transform.position.y <= startPos) { smashSource.Play(); } //if the block hits the ground, play the sound
        }  
        else { deadly = false; } //always set this value to false when the block isn't moving or not activated
    }

    //method used by the lever class to tell the block to move, or stop moving on the next update() call
    public void toggle()
    {
        activated = activated ? false : true;
    }

    //when either player collides with the block while it is falling
    //deal damage to the player
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("hurt player");
        if ((other.gameObject.tag == "Robot" || other.gameObject.tag == "Knight") && deadly)
        {
            Debug.Log("hurt player");
            other.gameObject.GetComponent<Destructable>().takeDamage(100);
        }
    }
}
