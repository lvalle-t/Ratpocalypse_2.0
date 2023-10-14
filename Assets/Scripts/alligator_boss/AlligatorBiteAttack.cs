
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlligatorBiteAttack : MonoBehaviour
{
    public int attackDamage = 20;
    public Vector3 attackOffset;
    public float attackRange = 3f;
    public LayerMask attackMask;

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        /*
            "Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);"

            Creating a hitbox when in range

            AttackMask is checking in a specific layer for a game object, otherwise,
            the collider would grab itself

            Make sure player is on layer "Player"
        */
        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            Debug.Log("Collision " + colInfo.gameObject);
            colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);

        }
    }

}
