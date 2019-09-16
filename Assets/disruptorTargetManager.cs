using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disruptorTargetManager : MonoBehaviour
{
    #region Singleton
    public static disruptorTargetManager instance;
    void Awake() {
        instance= this;
    }
    #endregion
    
    public PressurePlate[] plates;
   
}
