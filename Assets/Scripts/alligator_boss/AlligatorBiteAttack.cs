// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class AlligatorBiteAttack : MonoBehaviour
// {
//     // Start is called before the first frame update

//     public int attackDamage = 20;


//     public Vector3 attackOffset;
//     public float attackRange = 3f;
//     // public LayerMask attackMask;
//     public void Attack()
//     {
//         Vector3 pos = transform.position;
//         pos += transform.right * attackOffset.x;
//         pos += transform.up * attackOffset.y;

//         Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange);
//         if (colInfo != null)
//         {

//             colInfo.GetComponent<PlayerHpController>().TakeDamage(attackDamage);

//         }
//     }

// }
