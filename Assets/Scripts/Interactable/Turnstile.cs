using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This is used in level 3 for the turnstile all players must push at once
 * This object has a disabled 'Pushable' script attached to allow the players to correctly animate
 * The direction the turnstile will turn is determined by the sides it is pushed from
 */
public class Turnstile : MonoBehaviour
{
    public int playerspushing; //all players need to be pushed
    public Transform checkPoint; //which directions are the players pushing from
    public bool turned; //successfully turned
    public bool clockwise = false;
    public float rotateStart;
    public float rotateTime;

    public GameObject level3Parent;

    // Start is called before the first frame update
    void Start()
    {
        playerspushing = 0;
        turned = false;
        rotateTime = 6.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //Check whether the turnstile is being pushed correctly
        if (!turned && playerspushing == 4)
        {
            rotateStart = Time.time;
            if (Physics.Raycast(checkPoint.transform.position, Vector3.up))
            {
                turned = true;
                clockwise = false;
            }
            else
            {
                turned = true;
                clockwise = true;
            }
        }
        //Move the turnstile appropriately
        if (turned && (Time.time < rotateStart+rotateTime))
        {
            if (clockwise)
            {
                transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime * 0.1f);
            }
            else
            {
                transform.Rotate(new Vector3(0, -45, 0) * Time.deltaTime * 0.1f);
            }
        }
        
        playerspushing = 0;
    }

    //Used by playerController to indicate a player pushing
    void playerPushing(int num)
    {
        playerspushing += num;
    }
    //Used by level 3 manager to identify success
    public bool getTurned()
    {
        return turned;
    }
}
