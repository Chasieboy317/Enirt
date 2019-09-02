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
    private float currentTime;
    private float startPos;
    private float currentPos;

    void Start()
    {
        falling = false;
        currentTime = 0.0f;
        startPos = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        currentPos = this.transform.transform.position.y;

        if (falling && currentTime >= waitTime)
        {
            this.transform.position += new Vector3(0.0f, -0.1f, 0.0f) * Time.deltaTime * fallingSpeed;
            if (this.transform.position.y <= startPos)
            {
                falling = false;
                currentTime = 0.0f;
            }
        }

        else if (!falling && currentTime >= restTime)
        {
            this.transform.position += new Vector3(0.0f, 0.1f, 0.0f) * Time.deltaTime * Speed;
            if (this.transform.position.y >= startPos + upHeight)
            {
                falling = true;
                currentTime = 0.0f;
            }
        }
    }

}
