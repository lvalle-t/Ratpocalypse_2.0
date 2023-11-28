using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Pathfinding;

public class ratKing_controller : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;
    public int scoreNum = 0;
    public bool isDead;
    // public GameObject rat_king_projectile;
    // public float startTimeBtwShots;
    // private float timeBtwShots;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // timeBtwShots = startTimeBtwShots;

    }

    // Update is called once per frame
    void Update()
    {
        // if (timeBtwShots <= 0)
        // {
        //     Instantiate(rat_king_projectile, transform.position, Quaternion.identity);
        //     timeBtwShots = startTimeBtwShots;
        // }
        // else
        // {
        //     timeBtwShots -= Time.deltaTime;
        // }
    }

    private void FixedUpdate()
    {

        LookAtPlayer();
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

}


//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("AttackBox"))
//         {
//             TakeDamage(damage);
//         }
//     }

//     public void TakeDamage(int damage)
//     {
//         Hitpoints -= damage;
//         Healthbar.SetHealth(Hitpoints, MaxHitpoints);
//         if (Hitpoints <= 0)
//         {
//             Destroy(gameObject);
//             ItemDrop();
//             ScoreCollection();
//         }
//     }

//     public void ScoreCollection()
//     {
//         scoreNum = updater.scoreCount += 100;                 // updates the score counter
//         Destroy(gameObject);
//         ItemDrop();
//     }

//     private void ItemDrop()
//     {
//         for (int i = 0; i < itemDrops.Length; i++)
//         {
//             Instantiate(itemDrops[i], transform.position, Quaternion.identity);
//         }
//     }
// }


