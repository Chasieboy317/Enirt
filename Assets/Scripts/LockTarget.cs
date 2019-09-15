using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockTarget : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject TARGET;
    // Start is called before the first frame update
    public GameObject getTarget(string tag, string script)
    {
        objects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject o in objects)
        {
            if (o.transform.gameObject.GetComponent(script) != null)
            {
                TARGET = o;
            }
        }
        return TARGET;
    }

   
}
