// https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=626s
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyDamage(float damage)
    {
        if ((updater.playerHp - damage) > 0f)
        {
            updater.playerHp -= damage;
        }
        else
        {
            updater.playerHp = 0f;
        }
        healthBar.UpdateHealth(updater.playerHp);
    }
}