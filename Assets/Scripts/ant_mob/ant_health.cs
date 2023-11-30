// // // https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=626s

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class ant_health : MonoBehaviour
{
    public int Hitpoints;
    public int MaxHitpoints = 5;
    public ant_healthbar Healthbar;
    public GameObject[] itemDrops;
    [Header("Effects")]
    public GameObject deathEffect;
    [Header("Exp Amount")]
    int expAmount = 50;
    void Start()
    {
        Hitpoints = MaxHitpoints;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
    }

    public void TakeDamage(int damage)
    {
        Hitpoints -= damage;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
        if (Hitpoints <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
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
}