using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ratKing_run : StateMachineBehaviour
{

    Transform player;
    Rigidbody2D rb;
    ratKing_controller boss;
    Transform boss_transform;

    public float speed = 1f;

    public float attackRange = 3f;
    public float throwRange = 5f;

    float cooldownTimer = 1f;
    bool onCooldown = false;

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
        Vector2 target = new Vector2(player.position.x, player.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);

        rb.MovePosition(newPos);

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("ratKing_strike");
        }
        if (Vector2.Distance(player.position, rb.position) <= throwRange)
        {
            animator.SetTrigger("ratKing_throw");
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
