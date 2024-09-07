using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //public Transform player; // Reference to the player
    public float speed = 2f; // Speed of enemy movement
    public float attackRange = 2f; // Distance to start "fighting"
    public float attackCooldown = 1f; // Attack cooldown in seconds
    private bool isAttacking = false;

    private void Update()
    {
        Transform player = GameObject.Find("weapon").transform; ;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // If within attack range, stop moving and attack
        if (distanceToPlayer <= attackRange)
        {
            if (!isAttacking)
            {
                StartCoroutine(AttackPlayer());
            }
        }
        else
        {
            // Move towards the player
            if(GameManager.instance.time > 10)
            {
                speed += 0.1f * Time.deltaTime;
            }
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    IEnumerator AttackPlayer()
    {
        isAttacking = true;
        // Perform attack (e.g., reduce player health)
        Debug.Log("Enemy is attacking the player!");
        FindObjectOfType<Weapon>().PlayerOnAttack();
        // Wait for the attack cooldown before allowing the next attack
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }
}
