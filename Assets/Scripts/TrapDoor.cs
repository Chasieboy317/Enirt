using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour
{
    public float open;
    public float speed;
    public GameObject Door;

    private bool triggered;
    private float startPos;

    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
        startPos = Door.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Door.transform.position.z);
        if (triggered)
        {
            if (Door.transform.position.z > startPos - open)
            {
                Door.transform.position += new Vector3(0.0f, 0.0f, -0.1f) * Time.deltaTime * speed;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        triggered = true;
    }
}
