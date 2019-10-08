using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikedPit : MonoBehaviour
{
    // Deal effectively infinte amount of damage to anything falling into the pit
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Destructable>()) {
            other.gameObject.GetComponent<Destructable>().takeDamage(100000000);
        }

    }
}
