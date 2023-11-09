// // // https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=626s

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class snake_health : MonoBehaviour
{
    public float Hitpoints;
    public float MaxHitpoints = 5f;
    public snake_healthbar Healthbar;
    public GameObject[] itemDrops;
    public float damaged = 0.2f;

    public int scoreNum = 0;

    void Start()
    {
        Hitpoints = MaxHitpoints;
        Healthbar.SetHealth(Hitpoints);
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
        Hitpoints -= damage;
        Healthbar.SetHealth(Hitpoints);
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
            Instantiate(itemDrops[i], transform.position, Quaternion.identity);
        }
    }
    public void ScoreCollection()
    {
        scoreNum = updater.scoreCount += 100;                 // updates the score counter
    }
}