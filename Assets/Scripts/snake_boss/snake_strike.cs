
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake_strike : MonoBehaviour
{
    public float attackDamage = 0.2f;
    public Vector2 attackOffset;
    public float attackRange = 5f;
    public LayerMask attackMask;

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo.gameObject.tag == "Player")
        {
            colInfo.GetComponent<PlayerHealth>().EnemyDamage(attackDamage);

        }

    }

}
