using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//**********************************************************************************
// This Script Was Created Using the Following Resources:
//    -https://youtu.be/0WiGsJqV7Ug?si=MmfmH19FKZRnPmMB
//**********************************************************************************

public class fire_damage : MonoBehaviour
{
    public int damage;
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag =="Player"){
            other.gameObject.GetComponent<PlayerHealth>().damageEnemy(damage);
        }
    }
}