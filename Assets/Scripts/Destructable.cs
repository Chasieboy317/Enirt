using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public int health;

    public void takeDamage(int d)
    {
        health -= d;

        if (d < 0)
        {
            Debug.Log("Destroyed");
            // Destroy object - might want to call specific script so that you can have particle effect
        }
    }
}
