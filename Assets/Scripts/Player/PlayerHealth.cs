// https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=626s
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthBar;

    public GameManagerScript gameManager;

    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public void EnemyDamage(float damage)
    // {
    //     if ((updater.playerHp - damage) > 0f)
    //     {
    //         updater.playerHp -= damage;
    //     }
    //     else
    //     {
    //         updater.playerHp = 0f;
    //     }
    //     healthBar.UpdateHealth(updater.playerHp);
    // }

    public void EnemyDamage(float damage)
    {
        updater.playerHp -= damage;

        healthBar.UpdateHealth(updater.playerHp);

        if (updater.playerHp <= 0f && !isDead)
        {   
            updater.playerHp = 0f;
            isDead = true;
            gameManager.gameOver();
            Debug.Log("Player is dead!"); // Print "dead" message to the console
        }
    }


}