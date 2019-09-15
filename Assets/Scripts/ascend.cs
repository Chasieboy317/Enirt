using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ascend : MonoBehaviour
{
    public float deltaY;
    public float speed;
    public float finalY;
    public bool up;
    // Start is called before the first frame update
    void Start()
    {
        finalY = this.transform.position.y + deltaY;
    }

    // Update is called once per frame
    void Update()
    {
        if (up && this.transform.position.y < finalY)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + speed * deltaY * Time.deltaTime, this.transform.position.z);
        }
        else if (!up && this.transform.position.y > finalY)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - speed * deltaY * Time.deltaTime, this.transform.position.z);

        }
    }
}
