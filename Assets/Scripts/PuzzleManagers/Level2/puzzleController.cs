using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Controls whether or not puzzles have been completed. Used to activate/deactive elements of all connected puzzles
*/
public class puzzleController : MonoBehaviour
{
    public bool isCleared;
    public Spawner[] spawners;
    public bool puzzleReady = true;
    public GameObject[] objectsToActivate; // List of activatable gameObjects

    void Start() {
        isCleared = false;
    } 

    public void Update() {
        if (puzzleReady) {
            if (objectsToActivate.Length > 0) {
                foreach (GameObject c in objectsToActivate) {
                    c.SetActive(true);
                }
            }
        }
    }

    // Set puzzle to cleared, and deactivate this puzzles spawners
    public void Clear() {
        isCleared = true;
        foreach (Spawner spawner in spawners) {
            spawner.SetActive(false);
        }
    }
}
