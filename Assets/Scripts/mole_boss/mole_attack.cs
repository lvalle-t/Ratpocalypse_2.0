using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//**********************************************************************************
// This Script Was Created Using the Following Resources:
//    - https://pll.harvard.edu/course/cs50s-introduction-game-development
//    - https://docs.unity3d.com/Manual/index.html
//    - Text MeshPro Unity Sample Scripts
//**************************************************************************deb*****

public class mole_attack : MonoBehaviour
{
    public PlayerHealth hm;           // player health manager -deb
    public float damage = 1f;

    private void OnTriggerEnter2D(Collider2D collision)         // detects collition -deb
    {
        if (collision.tag == "Player")
        {
            hm.EnemyDamage(damage);
            //GetComponent<PlayerHealth>().EnemyDamage(damage);
        }
    }
}
