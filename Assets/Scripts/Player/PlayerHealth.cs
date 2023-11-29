// https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=626s
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Effects")]
    public GameManagerScript gameManager;
    public HealthBar healthBar;
    private bool isDead;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public Animator myAnimator;

    public GameObject go;
    public GameObject deathEffect;

    private void Update()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {

        //make sure that player health cannot be more than max health
        /*if(updater.playerHp > updater.maxHp){ 
            updater.playerHp = updater.maxHp;
        }*/

        for (int i = 0; i < hearts.Length; i++)
        {

            if (i < updater.playerHp && ((i + 0.5) == updater.playerHp))
            {
                hearts[i].sprite = halfHeart;
            }
            else if (i < updater.playerHp)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < updater.maxHp)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void EnemyDamage(float damage)
    {
        updater.playerHp -= damage;

        healthBar.UpdateHealth(updater.playerHp);
        UpdateHealth();

        if (updater.playerHp <= 0 && !isDead)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            myAnimator.SetTrigger("isDead");
            isDead = true;



            StartCoroutine(ShowGameOverScreenAfterAnimation());
            Debug.Log("Player is dead!"); // Print "dead" message to the console
        }
    }

    public void LifePurchase(float restore)
    {
        updater.playerHp += restore;

        healthBar.UpdateHealth(updater.playerHp);
        UpdateHealth();
    }

    IEnumerator ShowGameOverScreenAfterAnimation()
    {
        // Wait for the death animation to complete
        yield return new WaitForSeconds(myAnimator.GetCurrentAnimatorClipInfo(0).Length);

        // Show the game over screen
        go.SetActive(true);
        gameManager.gameOver();
        gameObject.SetActive(false);
    }

}

/* old code

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
    */