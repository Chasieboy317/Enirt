using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Keep a static reference to all players within the game.

Allows efficient aquisition to players by spawned in prefabs
*/
public class playerManager : MonoBehaviour
{
    #region Singleton
    public static playerManager instance;
    void Awake() {
        instance= this;
    }
    #endregion

    public GameObject[] players;
}
