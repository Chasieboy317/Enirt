using System.Collections;
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
        Debug.Log(direction);
        pushed = true;
        endPoint = this.transform.position + (direction * pushDistance);
        startTime = Time.time;
        pushDistance = 05f;
        //check if it would be pushed into something
        /*
        RaycastHit obstacle;
        if(Physics.Raycast(this.transform.position, direction * 0.5f, out obstacle))
        {
            pushDistance = Vector3.Distance(obstacle.point, this.transform.position);
                //float dist = Vector3.Distance(hitObj.point, transform.position);
        }
        else
        {
            pushDistance = 0.5f;
        }
        */
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
    }
}
