using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this class provides full functionality for the health bars
public class HealthBar : MonoBehaviour
{
    public PlayerController player;
    public Image healthBar;

    private float fill; //this value is a percentage and dictates how full the health bar should be based on the players health. E.g 62hp = 0.62, 62% full

    //intialize all variables and render the starting value of the players' health bars
    void Start()
    {
        fill = player.GetComponent<Destructable>().health/10;
        //fill = (float)player.health / 10;
        healthBar.fillAmount = fill;
        Debug.Log("Poes");
    }

    //update the health bar on every update
    void Update()
    {
        fill = player.GetComponent<Destructable>().health/10;
        //fill = (float)player.health / 10;
        healthBar.fillAmount = fill;
    }
}
