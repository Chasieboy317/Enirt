using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is used to control the automated smashing blocks in level1
public class DeathTrapScript : MonoBehaviour
{
    public float Speed; //the speed at which the block rises
    public float fallingSpeed; //the speed at which the block falls
    public float waitTime; //the time the block will wait before falling
    public float restTime; //the time the block will wait before rising
    public float upHeight; //the distance the block will travel to before stopping
    
    private bool falling; //boolean used to check the state of the block
    private bool deadly; //boolean used to check if the block is deadly, true if the block is falling, false if the block is going up. This value is used to check if damage should be dealt to a player
    private float currentTime; 
    private float startPos; //the initial position of the block, used to check when the block should stop going up
    private float currentPos; //the current position of the block

    private AudioSource smashSource;
    
    //intitialize all variables
    //get the audio source of the block
    void Start()
    {
        falling = false;
        deadly = false;
        currentTime = 0.0f;
        startPos = this.transform.position.y;
        smashSource = GetComponent<AudioSource>();
    }

    //move the block every update
    void Update()
    {
        move();
    }

    //this method controls the movement of the block
    //and whether the block is deadly or not
    void move()
    {
        currentTime += Time.deltaTime;
        currentPos = this.transform.transform.position.y;

        if (falling && currentTime >= waitTime) //if the trap is falling and the wait time is exceeded, make the trap fall down
        {
            this.transform.position += new Vector3(0.0f, -0.1f, 0.0f) * Time.deltaTime * fallingSpeed;
            if (this.transform.position.y <= startPos) //if the trap has reached the ground, reset falling so that it will go back up on the next iteration
            {
                smashSource.Play(); //play the sound when the block hits the ground
                falling = false;
                deadly = false;
                currentTime = 0.0f;
            }
        }

        else if (!falling && currentTime >= restTime) //if the trap is not falling and the rest time is exceeded, move the trap back up
        {
            this.transform.position += new Vector3(0.0f, 0.1f, 0.0f) * Time.deltaTime * Speed;
            if (this.transform.position.y >= startPos + upHeight) //if the trap has reached the top, reset falling so that it will go back down on the next iteration
            {
                falling = true;
                deadly = true;
                currentTime = 0.0f;
            }
        }
    }

    //this method is used to deal damage to the player on collision if the block is deadly
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("hurt player");
        if ((other.gameObject.tag=="Robot"||other.gameObject.tag=="Knight")&&deadly)
        {
            Debug.Log("hurt player");
            other.gameObject.GetComponent<Destructable>().takeDamage(100);
        }
    }

}
