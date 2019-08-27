﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    
    bool pushed = false;
    private float speed = 0.1f;
    Vector3 direction;

    public Transform start;
    public Transform end;
    public float startTime;
    private float pushDistance = 0.5f;// 0.86f;
    Vector3 endPoint;

    // Update is called once per frame
    void Update()
    {
        if (pushed)
        {
            float distCovered = (Time.time - startTime) * speed;
            //fraction of journey completed
            float fracJourney = distCovered / pushDistance;

            //move in direction of push
            transform.position = Vector3.Lerp(this.transform.position,endPoint, fracJourney);

            Debug.Log("x and z");
            Debug.Log(this.transform.position.x);
            Debug.Log(this.transform.position.z);

            if (distCovered >= pushDistance)
            {
                pushed = false;
            }
        }
        
    }
    public void wasPushed(Vector3 direction)
    {
        Debug.Log("Message received");
        this.direction = direction;
        pushed = true;
        endPoint = this.transform.position + (direction * pushDistance);
        startTime = Time.time;
    }
}
