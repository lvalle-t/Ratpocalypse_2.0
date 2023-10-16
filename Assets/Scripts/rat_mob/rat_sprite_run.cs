using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat_sprite_walking : StateMachineBehaviour
{
    public float speed =2.5f;
    public float stoppingDistance = .3f; // Adjust this value for your desired stopping distance

    public float attackRange = 1f;
    Transform player;
    Rigidbody2D rb;
    Rat_Mob Rat_Mob;

    // Animator animator;

    //**********************************************************************************
    // This Script Was Created Using the Following Resources:
    //   -https://youtu.be/AD4JIXQDw0s?si=Zp_4ksVC-M6hYZ0-
    //**********************************************************************************

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player= GameObject.FindGameObjectWithTag("Player").transform;
       rb=animator.GetComponent<Rigidbody2D>();
        Rat_Mob = animator.GetComponent<Rat_Mob>();
      
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        Rat_Mob.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, player.position.y);
        Vector2 direction = (target - rb.position).normalized;
        Vector2 newPos = rb.position;

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            // Start attacking when the player is within attack range
            animator.SetTrigger("rat_mob_attack");
        }
        else if (Vector2.Distance(player.position, rb.position) > stoppingDistance)
        {
            // Move towards the player if they are outside the stopping distance
            newPos = rb.position + direction * speed * Time.fixedDeltaTime;
        }

        rb.MovePosition(newPos);
       

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.ResetTrigger("rat_mob_attack");
    }
}
