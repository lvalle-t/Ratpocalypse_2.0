using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ant_test : MonoBehaviour
{
    
    public float _health = 3;
    public int Hitpoints;
    public spider_healthbar Healthbar;


    private FlashDamage flashDamage;

    void Start()
    {
        flashDamage = GetComponent<FlashDamage>();
    }
    public float Health
    {
       set
       {
           _health = value;

           if (_health <= 0)
           {
               Destroy(gameObject);
           }
       }
       get
       {
           return _health;
       }
    }
    void TakeDamage(float damage)
    {
       flashDamage.FlashOnDamage();
       Debug.Log("Ant Hit " + damage);
       Health -= damage;
    }
}

