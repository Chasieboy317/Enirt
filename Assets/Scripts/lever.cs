using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    public bool activated;
    // Start is called before the first frame update
    void Start()
    {
        activated = false;
    }

    // Update is called once per frame
    void activate()
    {
        if (!activated)
        {
            activated = true;
        }
        else
        {
            activated = false;
        }
        
    }
}
