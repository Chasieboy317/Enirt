using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienShipTorpedo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] robots;
    public GameObject target;
    
    void Start()
    {
        robots = GameObject.FindGameObjectsWithTag("ROBOT");
        foreach(GameObject r in robots)
        {
            if (r.GetComponent("RobotDoppelganger") != null)
            {
                target = r;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        while (this.transform.position.y > target.transform.position.y + 1)
        {
            this.transform.position = new Vector3( this.transform.position.x, this.transform.position.y - (1 * Time.deltaTime), this.transform.position.z);
        }
    }
}
