// // // https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=626s

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
//using UnityEngine.UI;

public class snake_health : MonoBehaviour
{
    public float Hitpoints;
    public float MaxHitpoints = 7f;
    public snake_healthbar Healthbar;
    public GameObject[] itemDrops;
    public float damaged = 1f;
    public int scoreNum = 0;


    public GameObject enemy;
    private bool hasSpawnedEnemy = false; // New variable to track whether the enemy has been spawned


    public bool isInvulnerable = false;

    private GameObject door_exit;
    private GameObject door_exit_bg;
    private GameObject snake;
    private FlashDamage flashDamage;

    SpriteRenderer m_SpriteRenderer;
    Color m_NewColor;
    int expAmount = 100;

    void Start()
    {
        Hitpoints = MaxHitpoints;
        Healthbar.SetHealth(Hitpoints);

        // m_SpriteRenderer = GetComponent<SpriteRenderer>();
        snake = GameObject.Find("snake");
        m_SpriteRenderer = snake.GetComponent<SpriteRenderer>();
        flashDamage = GetComponent<FlashDamage>();

        Debug.Log(snake);
        Debug.Log(m_SpriteRenderer);

        door_exit_bg = GameObject.Find("Door Bg");
        door_exit = GameObject.Find("Door Exit");

        door_exit_bg.SetActive(false);
        door_exit.SetActive(false);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("AttackBox"))
        {
            TakeDamage(damaged);
        }
    }

    public void TakeDamage(float damage)
    {
        if (isInvulnerable)
        {
            return;
        }

        flashDamage.FlashOnDamage();

        Hitpoints -= damage;
        Healthbar.SetHealth(Hitpoints);

        if (Hitpoints <= 34 && !hasSpawnedEnemy) // Check if hitpoints are below 34 and enemy hasn't been spawned
        {
            Instantiate(enemy, new Vector3(0, 0, 0), Quaternion.identity);
            hasSpawnedEnemy = true; // Set the flag to true after spawning the enemy
            GetComponent<Animator>().SetBool("isEnraged", true);
            m_SpriteRenderer.color = Color.red;
        }

        if (Hitpoints <= 0)
        {
            Destroy(gameObject);

            door_exit_bg.SetActive(true);
            door_exit.SetActive(true);
            ExperienceManager.Instance.AddExperience(expAmount);
            ItemDrop();
        }
    }

    private void ItemDrop()
    {
        for (int i = 0; i < itemDrops.Length; i++)
        {
            Instantiate(itemDrops[i], transform.position, Quaternion.identity);
        }
    }
    //public void ScoreCollection()
    //{
    //    scoreNum = updater.scoreCount += 100;                 // updates the score counter
    //}
}