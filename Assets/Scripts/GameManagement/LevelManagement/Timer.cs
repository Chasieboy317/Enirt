using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Script used by the UI to display the time remaining
 */
public class Timer : MonoBehaviour
{
    public float totalTime;
    private float currentTime;
    private UnityEngine.UI.Text text;
    private int minutes = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0.0f;
        text = gameObject.GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = calcMinutes(totalTime - currentTime);
        currentTime += Time.deltaTime;
        //Time over - restarts the level
        if (currentTime >= totalTime)
        {
            Debug.Log("end");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }     
    }

    string calcMinutes(float currentTime)
    {
        int minutes = 0;
        string result;
        minutes = (int)currentTime / 60;
        currentTime = Mathf.Round(currentTime % 60);
        string i = currentTime.ToString("00");
        result =  minutes + ":" + i;
        return result;

    }
}
