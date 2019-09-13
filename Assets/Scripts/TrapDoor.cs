using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour
{
    public float open = 5f; // Offset from starting position that is considered the open position
    public float speed = 1f;
    public GameObject Door;
    public moveDirection direction; // Direection the object opens to (moving up or down for open)

    public enum moveDirection {
        UP,
        DOWN
    };

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
            if (direction == moveDirection.UP) {
                if (Door.transform.position.z < startPos + open)
                {
                    Door.transform.position += new Vector3(0.0f, 0.0f, 0.1f) * Time.deltaTime * speed;
                }
            }
            else if (direction == moveDirection.DOWN)
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
