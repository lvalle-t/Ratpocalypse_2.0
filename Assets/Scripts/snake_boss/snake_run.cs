using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake_run : StateMachineBehaviour
{

    Transform player;
    Rigidbody2D rb;
    snake_controller boss;
    //Transform boss_transform;

    public float speed = 2.5f;

    public float attackRange = 1.8f; //for bite attack

    float cooldownTimer = 4f;
    bool onCooldown = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //boss_transform = GameObject.FindGameObjectWithTag("snake_boss").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<snake_controller>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, player.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);

        rb.MovePosition(newPos);

        if (onCooldown == true)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                onCooldown = false;
                cooldownTimer = 4;
            }
        }

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            if (!onCooldown)
            {
                animator.SetTrigger("snake_strike");

                onCooldown = true;
            }
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("snake_strike");

    }


    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}
}
