// // https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=626s
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ant_health : MonoBehaviour
{

    public int maxHealth = 5;
    public int currentHealth;
    public HealthBar healthBar;

    private bool isDead;

    public GameManagerScript gameManager;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            Debug.Log("I am Dead!");
            Destroy(gameObject);

        }
    }

    public void damaged(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

}