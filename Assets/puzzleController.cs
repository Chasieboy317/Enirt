using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleController : MonoBehaviour
{
    public bool isCleared;
    public Spawner[] spawners;

    void Start() {
        isCleared = false;
    } 

    public void Clear() {
        isCleared = true;
        foreach (Spawner spawner in spawners) {
            spawner.SetActive(false);
        }
    }
}
