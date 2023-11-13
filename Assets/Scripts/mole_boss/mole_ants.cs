using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mole_ants : MonoBehaviour
{
    public float damage;
    public mole_ants_slider Healthbar;
    public GameObject[] itemDrops;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AttackBox"))
        {
            TakeDamage(damage);
        }
    }

    private void TakeDamage(float damage)
    {
        if ((updater.moleHp - damage) > 0f)
        {
            updater.moleHp -= damage;
        }
        else
        {
            updater.moleHp = 0f;
            Destroy(gameObject);
            ItemDrop();
        }
        Healthbar.SetHealth(updater.moleHp);
    }

    private void ItemDrop()
    {
        for (int i = 0; i < itemDrops.Length; i++)
        {
            Instantiate(itemDrops[i], transform.position, Quaternion.identity);
        }
    }
}
