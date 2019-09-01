using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class main_menu : MonoBehaviour {

    /* 
     * Level 1 has scene index 1
     * Level 2 has scene index 2
     * Level 3 has scene index 3
     * */

    /* Level has been completed
     * Returns to the main menu if level 3 has been completed
    * */
    public void PlayNextLevel() {
        if (SceneManager.GetActiveScene().buildIndex == 3) {
            SceneManager.LoadScene(0); // Return to main menu
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    /*
     * Load the selected level
     * */
    public void PlayLevel(int i) {
        SceneManager.LoadScene(i);
    }

    // Quit the game
    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
