using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int maxActive = 2; // Maximum number of AI that can be active from this spawner
    public float respawnTime;
    public enemy[] Enemy; // enemy prefabs
    public bool active; // is the spawner active
    public puzzleController lastPuzzle; // Reference to last puzzle - only activate when cleared
    public puzzleController currentPuzzle; // Reference to current puzle - stop when cleared

    private float spawnCountDown;
    private int enemiesAlive;
    private List<enemy> enemies;
    private float spawnOffest = 0.5f;

    void Start() {
        spawnCountDown = respawnTime;
        enemiesAlive = 0;
        active = false;
        enemies = new List<enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        active = lastPuzzle.isCleared && !currentPuzzle.isCleared;
        if (active){
            respawnTime -= Time.deltaTime; 
        }
    }

    void FixedUpdate() {
        if (enemiesAlive < maxActive && respawnTime <= 0) {
            enemy spawnedEnemy = Instantiate (Enemy[0], transform.position + new Vector3(0f,0f,spawnOffest), transform.rotation);
            spawnOffest*= -1;
            enemies.Add(spawnedEnemy);
            enemiesAlive++;
            respawnTime = spawnCountDown;
        }
    }

    public void SetActive(bool b) {
        gameObject.SetActive(b);
        
        if(!b) {
            foreach (enemy e in enemies) {
                e.Die();
            }
        }
    }
}
