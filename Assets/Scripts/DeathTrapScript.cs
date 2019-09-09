using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrapScript : MonoBehaviour
{
    public float Speed;
    public float fallingSpeed;
    public float waitTime;
    public float restTime;
    public float upHeight;
    
    private bool falling;
    private bool deadly;
    private float currentTime;
    private float startPos;
    private float currentPos;

    void Start()
    {
        falling = false;
        deadly = false;
        currentTime = 0.0f;
        startPos = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        currentPos = this.transform.transform.position.y;

        if (falling && currentTime >= waitTime) //if the trap is falling and the wait time is exceeded, make the trap fall down
        {
            this.transform.position += new Vector3(0.0f, -0.1f, 0.0f) * Time.deltaTime * fallingSpeed;
            if (this.transform.position.y <= startPos) //if the trap has reached the ground, reset falling so that it will go back up on the next iteration
            {
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

}
