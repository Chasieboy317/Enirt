using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerController player;
    public Image healthBar;

    private float fill;

    // Start is called before the first frame update
    void Start()
    {
        fill = (float)player.health / (float)100;
        healthBar.fillAmount = fill;
        Debug.Log(fill);
    }

    void update()
    {
        fill = (float)player.health / (float)100;
        healthBar.fillAmount = fill;
        healthBar.fillAmount = (float)(player.health / 100);
    }
}
