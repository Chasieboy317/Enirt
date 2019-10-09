using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this class provides all functionaliy for the pause menu
//the pause menu ui is defined in the ui canvas, along with all its buttons
//this class contains all the methods used by the buttons in the pause menu
public class PauseMenu : MonoBehaviour
{
    private bool toggle; //boolean used to freeze/continue the game and display/hide menu
    private GameObject pauseMenu; //the actual ui menu

    //initially keep the menu hidden until the player hits escape
    void Start()
    {
        pauseMenu = GameObject.FindWithTag("PauseMenu");
        pauseMenu.SetActive(false);
        toggle = false;
    }

    //when the player hits escape, hide or show the menu depending on the state
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!toggle) { pauseMenu.SetActive(true); FreezeGame(); }
            else { pauseMenu.SetActive(false); ContinueGame(); }
            toggle = !toggle;
        }
    }

    //reload the current scene
    //this method is used by the restart level button in the pause menu
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ContinueGame();
    }

    //return to the main menu
    //this method is used by the main menu button in the pause menu
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
        ContinueGame();
    }

    //quit the game entirely
    //this method is used by the quit game button in the pause menu
    public void QuitGame()
    {
        ContinueGame();
        Application.Quit();
    }

    //stop everything in the game from moving by setting the time scale to 0
    public void FreezeGame()
    {
        Time.timeScale = 0;
    }

    //continue from the last playing game state
    public void ContinueGame()
    {
        Time.timeScale = 1;
    }
}
