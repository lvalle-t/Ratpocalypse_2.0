using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float attackRange = 3.0f; // Adjust the attack range as needed
    public float attackCooldown = 1.0f; // Time between attacks
    public int attackDamage = 10; // Damage the enemy deals

    private Transform player;
    private bool canAttack = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Assumes the player has a "Player" tag
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            if (canAttack)
            {
                AttackPlayer();
                canAttack = false;
                Invoke("ResetAttackCooldown", attackCooldown);
            }
        }
    }

    private void AttackPlayer()
    {
        PlayerHealth2 playerHealth = player.GetComponent<PlayerHealth2>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }

    private void ResetAttackCooldown()
    {
        canAttack = true;
    }
}
