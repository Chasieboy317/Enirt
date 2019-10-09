using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script can be used to move a scene object up or down a certain distance
 */
public class ascend : MonoBehaviour
{
    public float deltaY;
    public float speed;
    public float finalY; //intended final position
    public bool up; //set false to move down

    // Start is called before the first frame update
    void Start()
    {
        if (up)
        {
            finalY = this.transform.position.y + deltaY;
        }
        else
        {
            finalY = this.transform.position.y - deltaY;
        }
    }

    // Update is called once per frame
    //Use move the object to it's final position smoothly over time
    void Update()
    {
        //move object upwards
        if (up && this.transform.position.y < finalY)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + speed * deltaY * Time.deltaTime, this.transform.position.z);
        }
        //move object downwards
        else if (!up && this.transform.position.y > finalY)
        {
            this.transform.position = new Vector3(this.transform.position.x, (this.transform.position.y - speed * deltaY * Time.deltaTime), this.transform.position.z);
        }
    }
}
