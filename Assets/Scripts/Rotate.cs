using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Brooke
//Just drag on
public class Rotate : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(45, 45, 45) * Time.deltaTime);
    }
}
