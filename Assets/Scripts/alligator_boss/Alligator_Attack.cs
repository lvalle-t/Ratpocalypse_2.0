using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alligator_Attack : MonoBehaviour
{
    public Animator gatorAnimator;

    public float tailDamage = 1f;
    public float biteDamage = 2f;
    public Vector3 attackOffset;
    public float biteAttackRange;
    public float tailAttackRange;
    public LayerMask attackMask;

    public float speed = 1f;
    float cooldownTimer = 5f;
    bool onCooldown = false;


    
    public void TailAttack()
    {
        if (!onCooldown)
        {
            Vector3 pos = transform.position;
            pos += transform.right * attackOffset.x;
            pos += transform.up * attackOffset.y;

            Collider2D colInfo = Physics2D.OverlapCircle(pos, tailAttackRange, attackMask);
            if (colInfo != null)
            {
                colInfo.GetComponent<PlayerHealth>().EnemyDamage(tailDamage);
            }
        }
        else
        {
            onCooldown = true;

            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                onCooldown = false;
                cooldownTimer = 5;
            }
        }
    }
    public void BiteAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, biteAttackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealth>().EnemyDamage(biteDamage);
        }
    }

    public void ExitAttack()
    {
        gatorAnimator.ResetTrigger("Alligator_bite");
        gatorAnimator.ResetTrigger("Alligator_tail_swipe");
    }
}
