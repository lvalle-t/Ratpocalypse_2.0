using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alligator_run : StateMachineBehaviour
{

    //private Transform player;
    //Rigidbody2D rb;
    //Alligator_Controller boss;
    //Transform boss_transform;

    //public GameObject tailSwipeWarningCircle;
    //public GameObject tailSwipeWarningCircleClone;
    //public float speed = 1f;

    //public float attackRange = 1.8f; //for bite attack
    //public float tailAttackRange = 3f;

    //float cooldownTimer = 5f;
    //bool onCooldown = false;

    //// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    player = GameObject.FindGameObjectWithTag("Player").transform;
    //    boss_transform = GameObject.FindGameObjectWithTag("Alligator_Boss").transform;
    //    rb = animator.GetComponent<Rigidbody2D>();
    //    boss = animator.GetComponent<Alligator_Controller>();
    //}

    //// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    //boss.LookAtPlayer();

    //    Vector2 target = new Vector2(player.position.x, player.position.y);
    //    Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);

    //    rb.MovePosition(newPos);

    //    /*
    //        checking of the attack is on cooldown 

    //        if it is decrement the cooldown

    //        then we check if cooldown is dont (or at 0), then set onCooldown to false allowing for
    //        the attack to take place

    //        reset cooldown timer
    //    */
    //    if (onCooldown == true)
    //    {
    //        cooldownTimer -= Time.deltaTime;
    //        if (cooldownTimer <= 0)
    //        {
    //            onCooldown = false;
    //            cooldownTimer = 5;
    //        }
    //    }

    //    if (Vector2.Distance(player.position, rb.position) <= attackRange)
    //    {
    //        animator.SetTrigger("Alligator_bite");
    //    }

    //    if (Vector2.Distance(player.position, rb.position) <= tailAttackRange && Random.Range(0f, 90000f) >= 89000f)
    //    {
    //        /*
    //            if player is in attack range for the tail attack 

    //            check if an attack is allowed (attack not on cooldown)

    //            we then instantiate a circle to show the hitbox of thetail attack so the player knows where to not be

    //            cooldown is now on true since an attack was just done
    //        */
    //        if (!onCooldown)
    //        {
    //            animator.SetTrigger("Alligator_tail_swipe");

    //            //getting the warning circle from prefab in alligator_boss/sprites , added to walking script in animator
    //            tailSwipeWarningCircleClone = Instantiate(tailSwipeWarningCircle, boss_transform.position, boss_transform.rotation);

    //            onCooldown = true;
    //        }
    //    }
    //}

    //// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    animator.ResetTrigger("Alligator_bite");
    //    animator.ResetTrigger("Alligator_tail_swipe");

    //    // destroy the instantiated circle after 1.2 seconds of displaying the circle
    //    Destroy(tailSwipeWarningCircleClone, 1.2f);
    //}


    //// OnStateMove is called right after Animator.OnAnimatorMove()
    ////override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    ////{
    ////    // Implement code that processes and affects root motion
    ////}
}
