using UnityEngine;
using Pathfinding;
public class EnemyController : MonoBehaviour
{
    public float attackRange = 3.0f; // Adjust the attack range as needed
    public float attackCooldown = 1.0f; // Time between attacks
    public float attackDamage = 0.2f; // Damage the enemy deals

    private Transform player;
    private bool canAttack = true;
    private AIPath aiPath;
    [SerializeField] private AudioSource spiderAttackSFX;
    private void Start()
    {
        aiPath = GetComponent<AIPath>();
        if (aiPath == null)
        {
            
            aiPath = gameObject.AddComponent<AIPath>();
        }
        player = GameObject.FindGameObjectWithTag("Player").transform; // Assumes the player has a "Player" tag
    }

    private void Update()
    {
        aiPath.orientation = OrientationMode.YAxisForward;
        aiPath.destination = player.position;
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            if (canAttack)
            {
                spiderAttackSFX.Play();
                AttackPlayer();
                canAttack = false;
                Invoke("ResetAttackCooldown", attackCooldown);
            }
        }
    }

    private void AttackPlayer()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.EnemyDamage(attackDamage);
        }
    }

    private void ResetAttackCooldown()
    {
        canAttack = true;
    }
}
