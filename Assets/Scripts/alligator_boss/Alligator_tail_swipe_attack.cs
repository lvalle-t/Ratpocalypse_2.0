
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alligator_tail_swipe_attack : MonoBehaviour
{
    public float attackDamage = 1f;
    public Vector3 attackOffset;
    public float attackRange = 3f;
    public LayerMask attackMask;


    public void tail_Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealth>().EnemyDamage(attackDamage);
        }
    }
}