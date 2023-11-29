using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ratKing_run : StateMachineBehaviour
{

    Transform player;
    Rigidbody2D rb;
    ratKing_controller boss;
    Transform boss_transform;

    public GameObject rat_king_projectile;

    public float speed = 1f;

    public float attackRange = 3f;
    public float throwRange = 5f;

    // float strikeCooldownTimer = 1f;
    // bool strikeOnCooldown = false;

    float projectileCooldowntimer = 2f;
    bool projectileOnCooldown = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boss_transform = GameObject.FindGameObjectWithTag("rat_king").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<ratKing_controller>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        // Vector2 target = new Vector2(player.position.x, player.position.y);
        // Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);

        // rb.MovePosition(newPos);

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("ratKing_strike");
        }

        if (projectileOnCooldown == true)
        {
            projectileCooldowntimer -= Time.deltaTime;
            if (projectileCooldowntimer <= 0)
            {
                projectileOnCooldown = false;
                projectileCooldowntimer = 2;
            }

        }
        if (Vector2.Distance(player.position, rb.position) <= throwRange && Random.Range(0f, 90000f) >= 89000f)
        {
            if (!projectileOnCooldown)
            {
                animator.SetTrigger("ratKing_throw");
                Instantiate(rat_king_projectile, boss_transform.position, Quaternion.identity);

                projectileOnCooldown = true;
            }
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("ratKing_strike");
        animator.ResetTrigger("ratKing_throw");
    }


    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}
}
