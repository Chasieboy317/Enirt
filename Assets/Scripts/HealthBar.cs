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
        fill = (float)player.health / (float)100;
        healthBar.fillAmount = fill;
        Debug.Log(fill);
    }

    //update the health bar on every update
    void update()
    {
        fill = (float)player.health / (float)100;
        healthBar.fillAmount = fill;
        healthBar.fillAmount = (float)(player.health / 100);
    }
}
