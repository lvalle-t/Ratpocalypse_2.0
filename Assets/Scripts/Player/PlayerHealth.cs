// https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=626s
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth=10;
    public int currentHealth;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
   	void Update(){
        if(currentHealth <= 0){
            Debug.Log("I am Dead!");
            Destroy(gameObject);

        }
    }

    public void damageEnemy(int damage){
        currentHealth-= damage;
        healthBar.SetHealth(currentHealth);
    }
}