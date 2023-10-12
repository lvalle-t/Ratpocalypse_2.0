// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;



// public class AttackArea : MonoBehaviour
// {
//     public Animator animator;

//     public Transform attackPoint;
//     public LayerMask enemyLayers;
//     public float attackRange =0.5f;
//     public int attackDamage=3;

//     void Update(){
//         if(Input.GetKeyDown(KeyCode.Space)){
//             Attack();
//         }
//     }

// 	void Attack()
// 	{
//         animator.SetTrigger("Attack");
// 		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);

//         foreach (Collider2D enemy in hitEnemies)
//         {
//             Debug.Log("We hit"+ enemy.name);
//             enemy.GetComponent<RatHealth>().TakeDamage(attackDamage);

//         }
// 	}
//     void OnDrawGizmosSelected(){
//         if(attackPoint==null){
//             return;
//         }
//         Gizmos.DrawWireSphere(attackPoint.position,attackRange);
//     }
	
// }

