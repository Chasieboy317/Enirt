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

    private float currentTime;
    private float waitTime;
    private bool cycle;
    private Vector3 startPos;
    private int currentIndex;

    // Start is called before the first frame update

    
    void Start()
    {
        waitTime = 1.0f / speed;
        currentTime = 0.0f;
        activated = false;
        cycle = true;
        startPos = transform.position;
        transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
        currentIndex = 0;
    }

    void Update()
    {
        move();
    }

    // Update is called once per frame
    public void toggle()
    {
        activated = activated ? false : true;
        cycle = true;
        currentTime = 0.0f;
        transform.position = startPos;
    }

    public void move()
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
