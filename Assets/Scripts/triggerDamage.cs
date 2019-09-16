using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDamage : MonoBehaviour
{
    public float damage;

   
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.GetComponent < Destructable > () != null)
        {
            other.transform.gameObject.GetComponent<Destructable>().SendMessage("takeDamage", damage);
        }
    }
}
