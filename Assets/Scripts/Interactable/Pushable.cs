using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Attach to scene objects that you wish to enable the players to be able to 'push'
 * These are objects without rigidbodies so can only be moved with this script
 */
public class Pushable : MonoBehaviour
{
    
    bool pushed = false;
    private float speed = 0.02f;
    Vector3 direction;

    public Transform start;
    public Transform end;
    public float startTime;
    private float pushDistance;// = 0.3f;// 0.86f;
    Vector3 endPoint;

    private float distCovered;

    // Update is called once per frame
    void Update()
    {
        //Object was pushed - linearly interpolate its position in the direction supplied
        if (pushed)
        {
            distCovered = (Time.time - startTime) * speed;
            //fraction of journey completed
            float fracJourney = distCovered / pushDistance;

            //move in direction of push
            transform.position = Vector3.Lerp(this.transform.position,endPoint, fracJourney);
            
            //Once the object has moved the appropriate distace - stop
            if (distCovered >= pushDistance)
            {
                pushed = false;
            }
        }
    }

    //object pushed in given direction. Other scripts call this method
    public void wasPushed(Vector3 direction)
    {
        this.direction = direction;
        pushed = true;
        endPoint = this.transform.position + (direction * pushDistance);
        startTime = Time.time;
        pushDistance = 1f;
        distCovered = 0f;
    }

}
