using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//level 1 end level if either player dies
public class Level1Manager : gameEndManager
{
    public GameObject Knight;
    public GameObject Robot;
    // Update is called once per frame
    void Update()
    {
        if (Knight == null || Robot == null)
        {
            //Game over, success = false. restart level
            GameOver(false);
        }
    }
}
