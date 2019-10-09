using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Simple script to just drag on to objects
//Will rotate object on all axes
public class Rotate : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(45, 45, 45) * Time.deltaTime *0.5f);
    }
}
