using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBlock : MonoBehaviour
{
    public float open;
    public float speed;

    public bool activated;
    private float startPos;
    // Start is called before the first frame update
    void Start()
    {
        activated = false;
        startPos = transform.position.y; 
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        transform.position += (activated && transform.position.y < startPos + open)  ? new Vector3(0.0f, 0.1f, 0.0f) * Time.deltaTime * speed : new Vector3(0.0f, 0.0f, 0.0f);
        transform.position += (!activated && transform.position.y > startPos) ? new Vector3(0.0f, -0.1f, 0.0f) * Time.deltaTime * speed : new Vector3(0.0f, 0.0f, 0.0f);
    }

    public void toggle()
    {
        activated = activated ? false : true;
    }
}
