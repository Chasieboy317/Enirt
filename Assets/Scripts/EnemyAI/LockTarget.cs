using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script encapsulates logic needed to find a player in the scene
//used to differentiate between finding the player / player doppelganger as they have the same tag, but different scripts
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
