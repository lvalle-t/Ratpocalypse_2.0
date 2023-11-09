using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class snake_controller : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;
    public int scoreNum = 0;        // adds to the scoreTxt count - deb
    public bool isDead;

    // public snake_healthBar healthBar;
    // public float damaged = 0.2f;

    private AIPath aiPath;


    void Start()
    {
        aiPath = GetComponent<AIPath>();
        if (aiPath == null)
        {
            aiPath = gameObject.AddComponent<AIPath>();
        }
        //rb = GetComponent<Rigidbody2D>();
        //batAnimator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        aiPath.destination = player.position;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
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


