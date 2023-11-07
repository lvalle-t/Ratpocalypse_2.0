using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat_Mob_Weapon : MonoBehaviour
{
	public float damage = 0.5f;
	//public Vector3 attackOffset;
	//public float attackRange = 1f;

	// public void Attack()
	// {
	// 	Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRange);

    //     foreach (Collider2D collider in colliders)
    //     {
    //         if (collider.CompareTag("Player"))
    //         {
    //             collider.GetComponent<PlayerHealth>().EnemyDamage(damage);
    //         }
    //     }
	// }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().EnemyDamage(damage);
        }
    }
	
}