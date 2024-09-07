using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject fishPrefab;
    public Transform[] spawnPositions;
    public Transform[] targetPositions;
    public float spawnInterval = 5f;
    public float moveSpeed = 2f;

    private void Start()
    {
        InvokeRepeating("SpawnFish", 0f, spawnInterval);
        InvokeRepeating("SpawnFish", 0f, spawnInterval);
        InvokeRepeating("SpawnFish", 0f, spawnInterval);
    }

    private void SpawnFish()
    {
        int randomIndex = Random.Range(0, spawnPositions.Length);
        Vector3 spawnPosition = spawnPositions[randomIndex].position;
        GameObject fish = Instantiate(fishPrefab, spawnPosition, Quaternion.Euler(0,0,-45));
        MoveFishToTarget(fish, randomIndex);
    }

    private void MoveFishToTarget(GameObject fish, int index)
    {
        if (index >= targetPositions.Length)
        {
            Destroy(fish);
            return;
        }

        Vector3 targetPosition = targetPositions[index].position;
        StartCoroutine(MoveFishCoroutine(fish, targetPosition));
    }

    private System.Collections.IEnumerator MoveFishCoroutine(GameObject fish, Vector3 targetPosition)
    {
        while (fish.transform.position != targetPosition)
        {
            fish.transform.position = Vector3.MoveTowards(fish.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        Destroy(fish);
    }
}
