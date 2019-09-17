using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turnstile : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerspushing;
    public Transform checkPoint;
    public bool turned;
    public bool clockwise = false;
    public float rotateStart;
    public float rotateTime;

    public GameObject level3Parent;
    void Start()
    {
        playerspushing = 0;
        turned = false;
        rotateTime = 6.5f;
    }

    // Update is called once per frame
    void Update()
    {
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
        else
        {
            
        }
        playerspushing = 0;
    }

    void playerPushing(int num)
    {
        playerspushing += num;
    }

    public bool getTurned()
    {
        return turned;
    }
}
