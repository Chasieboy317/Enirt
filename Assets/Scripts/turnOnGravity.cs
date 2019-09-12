using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOnGravity : MonoBehaviour
{

    public GameObject[] suspenders; // Rope keeping this bad boy hoisted

    private Rigidbody myRB;
    public bool enableGravity = false;
    public int destroyedSuspenders;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        myRB.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!enableGravity) {
            destroyedSuspenders = 0;
            foreach (GameObject obj in suspenders) {
                if (obj == null) {
                    destroyedSuspenders++;
                }
                if (destroyedSuspenders == suspenders.Length) {
                    enableGravity = true;
                    myRB.useGravity = true;
                }
            }
        }
    }
}
