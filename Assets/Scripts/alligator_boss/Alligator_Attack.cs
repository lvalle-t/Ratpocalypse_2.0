using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alligator_Attack : MonoBehaviour
{
    public Animator gatorAnimator;

    public float biteDamage = 2f;
    public Vector3 attackOffset;
    public float biteAttackRange;
    public LayerMask attackMask;
    

    public void BiteAttack()
    {
        gatorAnimator.SetTrigger("isAttacking");

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
        gatorAnimator.ResetTrigger("isAttacking");
    }
}
