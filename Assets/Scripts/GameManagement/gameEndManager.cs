using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This script is extended by level managers
 * It encapsulates the logic needed to restart a level or play the next level
 */
public class gameEndManager : MonoBehaviour
{
    //success true means next level loaded and false means replay current level
    public void GameOver(bool success)
    {
        if (success) //successful completion
        {
            PlayNextLevel();
        }
        else
        {
            //replay current level for now 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        Debug.Log("GameOver" + success);
    }

    //used to load the next level
    public void PlayNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(0); // Return to main menu
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
