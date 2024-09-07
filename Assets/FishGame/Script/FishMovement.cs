using UnityEngine;

public class FishMovement : MonoBehaviour
{
    private Vector3 targetPosition;
    float moveSpeed = 10;
    public void SetTargetPosition(Vector3 position)
    {
        targetPosition = position;
    }

    private void Update()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * moveSpeed);

        // Check if the fish has reached the target position
        if (transform.position == targetPosition)
        {
            Destroy(gameObject);
        }
    }
}
