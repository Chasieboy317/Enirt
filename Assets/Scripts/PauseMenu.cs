using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private bool toggle;
    private GameObject pauseMenu;
    void Start()
    {
        pauseMenu = GameObject.FindWithTag("PauseMenu");
        pauseMenu.SetActive(false);
        toggle = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!toggle) { pauseMenu.SetActive(true); FreezeGame(); }
            else { pauseMenu.SetActive(false); ContinueGame(); }
            toggle = !toggle;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ContinueGame();
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
        ContinueGame();
    }

    public void QuitGame()
    {
        ContinueGame();
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void FreezeGame()
    {
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
    }
}
