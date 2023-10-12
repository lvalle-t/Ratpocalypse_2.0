using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;

public class RatHealth : MonoBehaviour
{

	public int maxHealth=5;
    private int currentHealth;

	// public GameObject deathEffect;

    void Start(){
        currentHealth = maxHealth;
    }

	void Update(){
        if(currentHealth <= 0){
            Debug.Log("I am Dead!");
            Destroy(gameObject);
            //die animation drop treat

        }
    }

    public void TakeDamage(int attackDamage){
        currentHealth -= attackDamage;
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class RatHealth : MonoBehaviour
// {
//     [SerializeField] private int health = 5;

//     private int MAX_HEALTH = 5;

//     // Update is called once per frame
//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.D))
//         {
//             Damage(10);
//         }

//         if (Input.GetKeyDown(KeyCode.H))
//         {
//             Heal(10);
//         }
//     }

//     public void Damage(int amount)
//     {
//         if(amount < 0)
//         {
//             throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
//         }

//         this.health -= amount;

//         if(health <= 0)
//         {
//             Die();
//         }
//     }

//     public void Heal(int amount)
//     {
//         if (amount < 0)
//         {
//             throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
//         }

//         bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;

//         if (wouldBeOverMaxHealth)
//         {
//             this.health = MAX_HEALTH;
//         }
//         else
//         {
//             this.health += amount;
//         }
//     }

//     private void Die()
//     {
//         Debug.Log("I am Dead!");
//         Destroy(gameObject);
//     }
// }