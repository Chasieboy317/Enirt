using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBlock : MonoBehaviour
{
    public float open;
    public float speed;

    public bool activated;
    private bool deadly;
    private float startPos;
    // Start is called before the first frame update
    void Start()
    {
        deadly = false;
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
        if (activated && transform.position.y < startPos + open)
        {
            transform.position += new Vector3(0.0f, 0.1f, 0.0f) * Time.deltaTime * speed;
            deadly = false;
        }
        else if (!activated && transform.position.y > startPos)
        {
            transform.position += new Vector3(0.0f, -0.1f, 0.0f) * Time.deltaTime * speed;
            deadly = true;
        }  
        else { deadly = false; }
    }

    public void toggle()
    {
        activated = activated ? false : true;
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("hurt player");
        if ((other.gameObject.tag == "Robot" || other.gameObject.tag == "Knight") && deadly)
        {
            Debug.Log("hurt player");
            other.gameObject.GetComponent<Destructable>().takeDamage(100);
        }
    }
}
