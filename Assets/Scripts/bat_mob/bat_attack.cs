using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//**********************************************************************************
// This Script Was Created Using the Following Resources:
//    - https://pll.harvard.edu/course/cs50s-introduction-game-development
//    - https://docs.unity3d.com/Manual/index.html
//    - Text MeshPro Unity Sample Scripts
//**************************************************************************deb*****

public class bat_attack : MonoBehaviour
{
    //public PlayerHealth hm;           // player health manager -deb
    public float damage = 0.2f;

    private void OnTriggerEnter2D(Collider2D collision)         // detects collition -deb
    {

        /*
            Needed to change collision.tag -> collision.gameObject.tag

            Then add it to the get component line

            -Tristan fry
        */

        if (collision.gameObject.tag == "Player")
        {
            //hm.TakeDamage(0.2f);
            collision.gameObject.GetComponent<PlayerHealth>().EnemyDamage(damage);
        }
    }
}
