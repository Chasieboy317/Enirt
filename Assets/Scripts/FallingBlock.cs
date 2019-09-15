using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public float hangTime = 1f;
    public float collisionTime;
    public int collisions;

    void Update()
    {
        if (collisions > 1)
        {
           
        }

        if (collisions>=1 && Time.time > collisionTime + hangTime)
        {

        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        collisions++;

    }
}
