// // // https://www.youtube.com/watch?v=v1UGTTeQzbo&t=3s

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rat_health : MonoBehaviour
{

    public float Hitpoints;
    public float MaxHitpoints;
    public rat_healthbar Healthbar;
    
    [Header("Item Drops")]
    public GameObject[] itemDrops;
    public int scoreNum = 0;        // adds to the scoreTxt count - deb
    [Header("Sound")]
    [SerializeField] private AudioSource hitDamageSFX;
    [Header("Effects")]
    public GameObject deathEffect;
    private FlashDamage flashDamage;

    void Start()
    {
        Hitpoints = MaxHitpoints;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
        flashDamage = GetComponent<FlashDamage>();
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
        flashDamage.FlashOnDamage();
        Hitpoints -= damage;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
        hitDamageSFX.Play();
        if (Hitpoints <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            ItemDrop();
            //ScoreCollection();
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
    //public void ScoreCollection()
    //{
    //    scoreNum = updater.scoreCount += 50;                 // updates the score counter
    //}
}