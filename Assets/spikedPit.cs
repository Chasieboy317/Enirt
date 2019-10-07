using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikedPit : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Destructable>()) {
            other.gameObject.GetComponent<Destructable>().takeDamage(100000000);
        }

    }
}
