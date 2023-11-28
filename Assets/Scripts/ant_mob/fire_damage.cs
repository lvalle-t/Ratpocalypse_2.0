using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//**********************************************************************************
// This Script Was Created Using the Following Resources:
//    -https://youtu.be/0WiGsJqV7Ug?si=MmfmH19FKZRnPmMB
//*************************************************************************lv*******

public class fire_damage : MonoBehaviour
{
    public float damage = 0.2f;
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag =="Player"){
            other.gameObject.GetComponent<PlayerHealth>().EnemyDamage(damage);
        }
    }
}