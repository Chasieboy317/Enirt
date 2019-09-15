using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Turns on the gravtiy of a suspended object
*/
public class turnOnGravity : MonoBehaviour
{

    public GameObject[] suspenders; // Rope keeping this bad boy hoisted

    private Rigidbody myRB;
    public bool enableGravity = false;
    public int destroyedSuspenders; // Number of things keeping object suspended. All need to be destroyed for gravity to turn on
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        myRB.useGravity = false; // Object starts as suspended, thus no gravity
    }

    // Update is called once per frame
    public void onUpdate()
    {
        if (!enableGravity)
        { // Only loop if we know there are still suspenders active
            destroyedSuspenders = 0;
            foreach (GameObject obj in suspenders)
            {
                if (obj == null)
                {
                    destroyedSuspenders++;
                }
                if (destroyedSuspenders == suspenders.Length)
                { // if all suspenders are destroyed
                  // This can be generalized more with another variable to set how many suspenders need to be destroyed
                    enableGravity = true;
                    myRB.useGravity = true;
                }
            }
        }
    }
    void Update()
    {
        onUpdate();
    }
}
