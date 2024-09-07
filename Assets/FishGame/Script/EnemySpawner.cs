using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab
    public Transform[] spawnPoints; // Array of spawn points
    public Transform player; // Reference to the player
    public float spawnInterval = 5f; // Initial interval between spawns
    public int maxEnemies = 200; // Maximum number of enemies

    private float elapsedTime = 0f; // Track elapsed time
    public  int currentEnemyCount = 0; // Track the number of spawned enemies

    private void Start()
    {
        // Start the spawn loop
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Increment elapsed time
          

            // If time is greater than 20 seconds, reduce the spawnInterval
            if(spawnInterval > 1)
            {
                spawnInterval -= 0.05f;
            }
                ; // Set spawn interval to 1 second
            

            // Check if we have reached the max number of enemies
            if (currentEnemyCount < maxEnemies)
            {
                // Spawn enemy at a random spawn point
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

                // Increment the current enemy count
                currentEnemyCount++;
                print("enamy - count - " + currentEnemyCount);
            }

            // Wait for the next spawn based on the spawn interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
