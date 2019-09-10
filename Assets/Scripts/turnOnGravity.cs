using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOnGravity : MonoBehaviour
{

    public GameObject rope; // Rope keeping this bad boy hoisted
    Rigidbody myRB;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        myRB.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rope.activeSelf == false) {
            myRB.useGravity = true;
        }
        
    }
}
