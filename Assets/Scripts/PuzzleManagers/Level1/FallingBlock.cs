using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public float hangTime = 1f;
    public float collisionTime;
    public bool col;

    void Start()
    {
        
    }
    void Update()
    {

        if (col && Time.time > collisionTime + hangTime)
        {
            this.transform.gameObject.GetComponent<ascend>().enabled = true;
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (!col)
        {
            col = true;
            collisionTime = Time.time;
        }
    }
}
