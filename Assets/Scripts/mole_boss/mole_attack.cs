using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

//**********************************************************************************
// This Script Was Created Using the Following Resources:
//    - https://pll.harvard.edu/course/cs50s-introduction-game-development
//    - https://docs.unity3d.com/Manual/index.html
//    - Text MeshPro Unity Sample Scripts
//**************************************************************************deb*****

public class mole_attack : MonoBehaviour
{
    public float damage = 4f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().EnemyDamage(damage);
        }
    }

}
