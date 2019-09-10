using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour
{
    public float open;
    public float speed;
    public GameObject Door;
    public int direction;

    private bool triggered;
    private float startPos;

    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
        startPos = Door.transform.position.z;
    }

    //Direction: 1 means the door will open in the negative z direction
    //           -1 means the door will open in the positive z direction
    void Update()
    {
        if (triggered)
        {
            if (direction==1) {
                if (Door.transform.position.z < startPos + open)
                {
                    Door.transform.position += new Vector3(0.0f, 0.0f, 0.1f) * Time.deltaTime * speed;
                }
            }
            else if (direction==-1)
            {
                if (Door.transform.position.z > startPos - open)
                {
                    Door.transform.position += new Vector3(0.0f, 0.0f, -0.1f) * Time.deltaTime * speed;
                }
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        triggered = true;
    }
}
