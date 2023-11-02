using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth2 : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 10;
    public int health;
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage){
        health -= damage;
        if (health <= 0){
            Destroy(gameObject);
        }
    }
}
