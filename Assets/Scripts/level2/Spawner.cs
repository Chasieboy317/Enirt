using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Spawns enemies for the player to fend off
*/
public class Spawner : MonoBehaviour
{
    public int maxActive = 2; // Maximum number of AI that can be active from this spawner
    public float respawnTime; // Time before spawning a new enemy, as to not spawn all of them at once
    public enemy[] Enemy; // enemy prefabs
    public bool active; // is the spawner active
    public puzzleController lastPuzzle; // Reference to last puzzle - only activate when cleared
    public puzzleController currentPuzzle; // Reference to current puzle - stop when cleared

    private float spawnCountDown; // Keep track for the next spawn
    private int enemiesAlive; // Track how many are alive right now
    private List<enemy> enemies; // List of all enemies that hve been spawned
    private float spawnOffest = 1.5f; // Spawn enemies some distance apart to avoid agend collision

    void Start() {
        spawnCountDown = respawnTime;
        enemiesAlive = 0;
        active = false;
        enemies = new List<enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if there are more available AI slots
        active = lastPuzzle.isCleared && !currentPuzzle.isCleared && (enemiesAlive!=maxActive);
        if (active){
            // Only count down if an AI has been felled (do not immediately spawn another)
            respawnTime -= Time.deltaTime; 
        }

        // Track number of alive enemies
        int alive = 0;
        foreach (enemy e in enemies){
            if (e != null) {
                alive++;
            }
        }
        enemiesAlive = alive;
    }

    void FixedUpdate() {
        // Spawn a new enemy, and reset spawn time
        if (enemiesAlive < maxActive && respawnTime <= 0) {
            int r = Random.Range(0,Enemy.Length);
            enemy spawnedEnemy = Instantiate (Enemy[r], transform.position + new Vector3(0f,2f,spawnOffest), transform.rotation);
            spawnOffest*= -1;
            enemies.Add(spawnedEnemy);
            enemiesAlive++;
            respawnTime = spawnCountDown;
        }
    }

    // (De)Activate the spawner
    public void SetActive(bool b) {
        gameObject.SetActive(b);
        
        // If the puzzle gets turned off, all enemies need to die
        if(!b) {
            foreach (enemy e in enemies) {
                if (e) {
                    e.Die();
                }
            }
        }
    }
}
