
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ratKing_strike : MonoBehaviour
{
    public float attackDamage = 0.5f;
    public float enragedAttackDamage = 1f;
    public Vector2 attackOffset;
    public float attackRange = 5f;
    public LayerMask attackMask;

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            if (colInfo.gameObject.tag == "Player")
            {
                colInfo.GetComponent<PlayerHealth>().EnemyDamage(attackDamage);

            }
        }

    }

    public void EnragedAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            if (colInfo.gameObject.tag == "Player")
            {
                colInfo.GetComponent<PlayerHealth>().EnemyDamage(enragedAttackDamage);

            }
        }

    }

}
