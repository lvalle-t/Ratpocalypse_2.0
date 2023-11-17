
// // // https://www.youtube.com/watch?v=v1UGTTeQzbo&t=3s

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spider_health : MonoBehaviour
{

    public float Hitpoints;
    public float MaxHitpoints = 5;
    public spider_healthbar Healthbar;
    public GameObject[] itemDrops;
    private FlashDamage flashDamage;
    [SerializeField] private AudioSource spiderHitSFX;

    public int scoreNum = 0;        // adds to the scoreTxt count - deb
    // [SerializeField] private AudioSource hitDamageSFX;

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
        spiderHitSFX.Play();
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
        // hitDamageSFX.Play();
        if (Hitpoints <= 0)
        {
            Debug.Log("Taking damage: " + damage);
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

