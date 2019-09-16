using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    public bool activated;
    public Vector3 pivot;
    public Vector3 direction;
    public float maxAngle;
    public float speed;

    protected float currentTime;
    protected float waitTime;
    protected bool cycle;
    protected Vector3 startPos;

    protected int currentIndex;

    // Start is called before the first frame update

    
    protected void Start()
    {
        waitTime = 1.0f / speed;
        currentTime = 0.0f;
        activated = false;
        cycle = true;
        startPos = transform.position;
        transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);

        currentIndex = 0;
    }

    protected void Update()
    {
        move();
    }

    // Update is called once per frame
    public virtual void toggle()
    {
        activated = activated ? false : true;
        cycle = true;
        currentTime = 0.0f;
        transform.position = startPos;
    }

    protected void move()
    {
        if (activated)
        {
            currentTime += Time.deltaTime;
            if (cycle)
            {
                var rotation = transform.rotation;
                transform.RotateAround(pivot, direction, maxAngle * speed * Time.deltaTime);  
                transform.rotation = rotation;
                transform.Rotate(direction * maxAngle * speed * Time.deltaTime);
                if (currentTime>=waitTime) { cycle = false; currentTime = 0.0f; }
            }
            else
            {
                var rotation = transform.rotation;
                transform.RotateAround(pivot, direction, -maxAngle * speed * Time.deltaTime);
                transform.rotation = rotation;
                transform.Rotate(direction * -maxAngle * speed * Time.deltaTime);
                if (currentTime>=waitTime) {  toggle(); }
            }
        }
    }
}
