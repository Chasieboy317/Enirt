using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameEndManager : MonoBehaviour
{
    //success true means next level loaded and false means replay current level
    public void GameOver(bool success)
    {

        if (success)
        {
            PlayNextLevel();
        }
        else
        {
            //replay current level for now 
            SceneManager.LoadScene(3);
        }

        Debug.Log("GameOver" + success);
    }

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
