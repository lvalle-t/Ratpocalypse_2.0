// // // https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=626s

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ant_health : MonoBehaviour
{

    public int Hitpoints;
    public int MaxHitpoints = 5;
    public ant_healthbar Healthbar;
    public GameObject[] itemDrops;

    void Start()
    {
        Hitpoints = MaxHitpoints;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
    }


    // // testing area//
    // void Update(){
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         TakeDamage(1);
    //     }
    //     // testing area///
    // }

    public void TakeDamage(int damage)
    {
        Hitpoints -= damage;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
            ItemDrop();
        }
    }

    // public void TakeDamage(int damage)
    // {
    //     Hitpoints -= damage;
    //     HealthBar.SetHealth(Hitpoints);
    // }

    private void ItemDrop()
    {
        for (int i = 0; i < itemDrops.Length; i++)
        {
            // Instantiate(itemDrops[i],transform.position + new Vector3(0,1), Quaternion.identity );

            Instantiate(itemDrops[i], transform.position, Quaternion.identity);
        }
    }

}