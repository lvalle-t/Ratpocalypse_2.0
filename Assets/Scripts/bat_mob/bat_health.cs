// // // https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=626s

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class bat_health : MonoBehaviour
{
    public int Hitpoints;
    public int MaxHitpoints = 5;
    public bat_healthbar Healthbar;
    public GameObject[] itemDrops;

    public int scoreNum = 0;
    [Header("Effects")]
    public GameObject deathEffect;

    private FlashDamage flashDamage;
    [Header("Exp Amount")]
    int expAmount = 50;

    void Start()
    {
        Hitpoints = MaxHitpoints;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
        flashDamage = GetComponent<FlashDamage>();
    }

    public void TakeDamage(int damage)
    {
        flashDamage.FlashOnDamage();
        Hitpoints -= damage;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
        if (Hitpoints <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            ExperienceManager.Instance.AddExperience(expAmount);
            ItemDrop();
            //ScoreCollection();
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
    //    scoreNum = updater.scoreCount += 25;                 // updates the score counter
    //}
}