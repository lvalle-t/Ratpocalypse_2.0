// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;

// // // https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=626s

// // public class rat_health : MonoBehaviour
// // {

// //     public int maxHealth = 10;
// //     public int currentHealth;
// //     public HealthBar healthBar;

// //     private bool isDead;

// //     // Start is called before the first frame update
// //     void Start()
// //     {
// //         currentHealth = maxHealth;
// //         healthBar.SetMaxHealth(maxHealth);
// //     }

// //     // Update is called once per frame
// //     void Update()
// //     {
// //         if (Input.GetKeyDown(KeyCode.Space))
// //         {
// //             TakeDamage(1);
// //         }
// //         if (currentHealth <= 0 && !isDead)
// //         {
// //             isDead = true;
// //             Debug.Log("I am Dead!");
// //             Destroy(gameObject);

// //         }
// //     }

// //     public void TakeDamage(int damage)
// //     {
// //         currentHealth -= damage;
// //         healthBar.SetHealth(currentHealth);
// //     }
// // }


// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;
// // // using UnityEngine.SceneManagement;

// // public class RatHealth : MonoBehaviour
// // {

// // 	public int maxHealth=5;
// //     private int currentHealth;

// // 	// public GameObject deathEffect;

// //     void Start(){
// //         currentHealth = maxHealth;
// //     }

// // 	void Update(){
// //         if(currentHealth <= 0){
// //             Debug.Log("I am Dead!");
// //             Destroy(gameObject);
// //             //die animation drop treat

// //         }
// //     }

// //     public void TakeDamage(int attackDamage){
// //         currentHealth -= attackDamage;
// //     }
// // }



// // // https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=626s

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rat_health : MonoBehaviour
{

    public int Hitpoints;
    public int MaxHitpoints = 5;
    public rat_healthbar Healthbar;
    public GameObject[] itemDrops;

    public int scoreNum = 0;        // adds to the scoreTxt count - deb
    [SerializeField] private AudioSource hitDamageSFX;

    void Start()
    {
        Hitpoints = MaxHitpoints;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
    }


    // // testing area//
    // void Update(){
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         TakeDamage(3);
    //     }
    //     // testing area///
    // }

    public void TakeDamage(int damage)
    {
        Hitpoints -= damage;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
        hitDamageSFX.Play();
        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
            ItemDrop();
            ScoreCollection();
        }
    }

    private void ItemDrop()
    {
        for (int i = 0; i < itemDrops.Length; i++)
        {
            // Instantiate(itemDrops[i],transform.position + new Vector3(0,1), Quaternion.identity );

            Instantiate(itemDrops[i], transform.position, Quaternion.identity);
        }
    }
    public void ScoreCollection()
    {
        scoreNum = updater.scoreCount += 50;                 // updates the score counter
    }
}