using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is used for moving certain gameobjects once a player hits a trigger
public class TrapDoor : MonoBehaviour
{
    public float open = 5f; // Offset from starting position that is considered the open position
    public float speed = 1f; //speed at which the trapdoor will open
    public GameObject Door; //the object that will be moved when either player hits the trigger
    public moveDirection direction; // Direection the object opens to (moving up or down for open)

    //Direction: down means the door will open in the negative z direction
    //           up means the door will open in the positive z direction
    public enum moveDirection {
        UP,
        DOWN
    };

    private bool triggered; //boolean used to check whether the door should be moving or not
    private float startPos;
    private AudioSource openingSource;
    
    //initialize all the variables
    //and get the audio source for the opening door
    void Start()
    {
        triggered = false;
        startPos = Door.transform.position.z;
        openingSource = GetComponent<AudioSource>();
    }

    //method used to control the movement of the door if the trigger has been hit
    void Update()
    {
        if (triggered)
        {
            
            if (direction == moveDirection.UP) {
                if (Door.transform.position.z < startPos + open) //while the door still hasn't opened fully
                {
                    if (!openingSource.isPlaying) { openingSource.Play(); }
                    Door.transform.position += new Vector3(0.0f, 0.0f, 0.1f) * Time.deltaTime * speed; //open the door
                    if (Door.transform.position.z >= startPos + open) //if the door is fully opened, stop the sound
                    {
                        openingSource.Stop();
                    }
                }
            }
            else if (direction == moveDirection.DOWN)
            {
                if (Door.transform.position.z > startPos - open) //while the door still hasn't opened fully
                {
                    if (!openingSource.isPlaying) { openingSource.Play(); }
                    Door.transform.position += new Vector3(0.0f, 0.0f, -0.1f) * Time.deltaTime * speed; //open the door
                    if (Door.transform.position.z <= startPos - open) //if the door is fully opened, stop the sound
                    {
                        openingSource.Stop();
                    }
                }
            }
            
        }
    }

    //when either player collides with the trigger, get ready to open the door on the next update() call
    private void OnTriggerEnter(Collider other)
    {
        triggered = true;
    }
}
