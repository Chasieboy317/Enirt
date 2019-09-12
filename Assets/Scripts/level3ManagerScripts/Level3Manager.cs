using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Manager : MonoBehaviour
{
    public bool gameOver;
    

    //start timer?
    //win/lose conditions

    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            //end game //check win or loose
            Debug.Log("GameOver");
        }
    }

    public void GameOver()
    {
        gameOver = true;
    }
}
