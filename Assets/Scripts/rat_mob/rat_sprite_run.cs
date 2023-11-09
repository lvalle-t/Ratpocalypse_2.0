// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Rat_sprite_walking : StateMachineBehaviour
// {
//     public float speed =2.5f;
//     public float stoppingDistance = .3f; // Adjust this value for your desired stopping distance

//     public float attackRange = 1f;
//     Transform player;
//     Rigidbody2D rb;
//     Rat_Mob Rat_Mob;

//     // Animator animator;

//     //**********************************************************************************
//     // This Script Was Created Using the Following Resources:
//     //   -https://youtu.be/AD4JIXQDw0s?si=Zp_4ksVC-M6hYZ0-
//     //**********************************************************************************

//     // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
//     override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//     {
//        player= GameObject.FindGameObjectWithTag("Player").transform;
//        rb=animator.GetComponent<Rigidbody2D>();
//         Rat_Mob = animator.GetComponent<Rat_Mob>();

//     }

//     // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
//     override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//     {


//         Rat_Mob.LookAtPlayer();

//         Vector2 target = new Vector2(player.position.x, player.position.y);
//         Vector2 direction = (target - rb.position).normalized;
//         Vector2 newPos = rb.position;

//         if (Vector2.Distance(player.position, rb.position) <= attackRange)
//         {
//             // Start attacking when the player is within attack range
//             animator.SetTrigger("rat_mob_attack");
//         }
//         else if (Vector2.Distance(player.position, rb.position) > stoppingDistance)
//         {
//             // Move towards the player if they are outside the stopping distance
//             newPos = rb.position + direction * speed * Time.fixedDeltaTime;
//         }

//         rb.MovePosition(newPos);


//     }

//     // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
//     override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//     {
//        animator.ResetTrigger("rat_mob_attack");
//     }
// }


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Pathfinding;

// public class Rat_sprite_walking : MonoBehaviour
// {
//     public float attackRange = 1f;
//     Transform player;
//     AIPath aiPath;
//     //Rat_Mob Rat_Mob;

//     Animator animator; // Add the Animator reference

//     //**********************************************************************************
//     // This Script Was Created Using the Following Resources:
//     //   - https://youtu.be/AD4JIXQDw0s?si=Zp_4ksVC-M6hYZ0-
//     //**********************************************************************************

//     // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
//     void Start()
//     {
//         aiPath = GetComponent<AIPath>();
//         if (aiPath != null)
//         {
//             aiPath.destination = player.position;
//         }
//         animator = GetComponent<Animator>();
//         player = GameObject.FindGameObjectWithTag("Player").transform;
//         aiPath.destination = player.position;
//          // Change to "GetComponent<AIPath>()"
//         //Rat_Mob = GetComponent<Rat_Mob>(); // Change to "GetComponent<Rat_Mob>()"
//          // Add this line to get the Animator component

//         // Set the destination to the player's position
        
//     }

//     // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
//     void Update()
//     {
//         aiPath.destination = player.position;
//         if (Vector2.Distance(player.position, transform.position) <= attackRange)
//         {
//             // Start attacking when the player is within attack range
//             animator.SetTrigger("rat_mob_attack");
//         }
//     }

//     // OnStateExit is called when a transition ends, and the state machine finishes evaluating this state
//     // override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//     // {
//     //     animator.ResetTrigger("rat_mob_attack");

//     //     // Stop the AIPath component when exiting the state
//     //     if (aiPath != null)
//     //     {
//     //         aiPath.destination = transform.position;
//     //     }
//     // }
// }




using UnityEngine;
using Pathfinding;

public class rat_sprite_run : MonoBehaviour
{
    public float attackRange = 3.0f; // Adjust the attack range as needed
    public float attackCooldown = 1.0f; // Time between attacks
    public float attackDamage = 0.2f; // Damage the enemy deals

    private Transform player;
    private bool canAttack = true;
    private AIPath aiPath;
    Animator animator;
    [SerializeField] private AudioSource ratAttackSFX;

    private void Start()
    {
        aiPath = GetComponent<AIPath>();
        if (aiPath == null)
        {
            aiPath = gameObject.AddComponent<AIPath>();
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>(); // Assumes the player has a "Player" tag
    }

    private void Update()
    {
        aiPath.orientation = OrientationMode.YAxisForward;
        aiPath.destination = player.position;
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            if (canAttack)
            {
                ratAttackSFX.Play();
                animator.SetTrigger("rat_mob_attack");
                // AttackPlayer(); // Removed this line, the attack logic will be handled by the Attack function in the AnimationEvent
                canAttack = false;
                Invoke("ResetAttackCooldown", attackCooldown);
            }
        }
    }

    // This function will be called by the AnimationEvent
    public void Attack()
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



