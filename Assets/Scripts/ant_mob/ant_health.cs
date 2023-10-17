// // // https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=626s
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class ant_health : MonoBehaviour
// {

//     public int maxHealth = 5;
//     public int currentHealth;
//     public HealthBar healthBar;

//     private bool isDead;

//     public GameManagerScript gameManager;
//     // Start is called before the first frame update
//     void Start()
//     {
//         currentHealth = maxHealth;
//         // healthBar.SetMaxHealth(maxHealth);
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         // testing area//
//         if (Input.GetKeyDown(KeyCode.Space))
//         {
//             TakeDamage(1);
//         }
//         // testing area///

//         if (currentHealth <= 0 && !isDead)
//         {
//             isDead = true;
//             Debug.Log("I am Dead!");
//             Destroy(gameObject);
//         }
        
//     }

//     public void TakeDamage(int damage)
//     {
//         currentHealth -= damage;
//         healthBar.SetHealth(currentHealth);
//     }

// }



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ant_health : MonoBehaviour
{

    public int Hitpoints;
    public int MaxHitpoints=5;
    public ant_healthbar Healthbar;

    void Start(){
        Hitpoints = MaxHitpoints;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
    }


    // testing area//
    void Update(){
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }
        // testing area///
    }
    
    public void TakeDamage(int damage){
        Hitpoints -= damage;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
        if(Hitpoints <= 0){
            Destroy(gameObject);
        }
    }

    // public void TakeDamage(int damage)
    // {
    //     Hitpoints -= damage;
    //     HealthBar.SetHealth(Hitpoints);
    // }

    
}