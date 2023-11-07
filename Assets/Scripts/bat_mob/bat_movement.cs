using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

//**********************************************************************************
// This Script Was Created Using the Following Resources:
//    - https://pll.harvard.edu/course/cs50s-introduction-game-development
//    - https://docs.unity3d.com/Manual/index.html
//    - Text MeshPro Unity Sample Scripts
//**************************************************************************deb*****

public class bat_movement : MonoBehaviour
{
    public bat_attack ba;              // bat attack manager
    //public Bat_hp_slider healthBar;
    public bool isDead;
    //private int harm;

    public Transform player;
    public float speed = 2f;
    //public float smoothMove = 0.1f;
    public float stoppingDistance = .1f; // tells mole how far it can go before it will overlap
    public float attackRange = 1f;

    private Rigidbody2D rb;
    private Vector3 direction;
    private Vector2 move;

    public Animator batAnimator;
    public int scoreNum = 0;        // adds to the scoreTxt count - deb
    public GameObject[] itemDrops;
    private AIPath aiPath;

    // Start is called before the first frame update
    void Start()
    {
        aiPath = GetComponent<AIPath>();
        if (aiPath == null)
        {
            aiPath = gameObject.AddComponent<AIPath>();
        }
        rb = GetComponent<Rigidbody2D>();
        batAnimator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        aiPath.destination = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        isDead = false;
        aiPath.destination = player.position;
        // direction = player.position - transform.position;
        // direction.Normalize();
        // move = direction;
        if (Vector2.Distance(player.position, transform.position) <= attackRange)
        {
            batAnimator.SetTrigger("isAttacking");
        }

    }

    // private void FixedUpdate()
    // {
    //     Vector2 target = new Vector2(player.position.x, player.position.y);
    //     Vector2 direction = (target - rb.position).normalized;
    //     Vector2 newPos = rb.position;
    //     rb.MovePosition(newPos);
    // }

    // void Follow(Vector2 direction)
    // {
    //     Vector3 flipped = transform.localScale;
    //     flipped.z *= -1f;

    //     if (transform.position.x < player.position.x && isFlipped)
    //     {
    //         SetAnimatorMovement(direction);
    //     }
    //     else if (transform.position.x > player.position.x && !isFlipped)
    //     {
    //         SetAnimatorMovement(direction);
    //     }

    //     rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    // }

    private void SetAnimatorMovement(Vector2 direction)
    {
        batAnimator.SetLayerWeight(0, 1);
        batAnimator.SetFloat("xDir", direction.x);
        batAnimator.SetFloat("yDir", direction.y);
        print(batAnimator.GetFloat("xDir"));
    }

    //     private void OnTriggerEnter2D(Collider2D collision)
    //     {
    //         if (collision.gameObject.CompareTag("PlayerHitBox"))
    //         {
    //             TakeDamage(20);
    //         }
    //     }

    //     private void TakeDamage(int damage)
    //     {
    //         if ((updater.batHp - damage) > 0)
    //         {
    //             updater.batHp -= damage;
    //         }
    //         else
    //         {
    //             updater.batHp = 0;
    //             batAnimator.SetTrigger("isDead");

    //             Invoke("ScoreCollection", 1);
    //             //yield return new WaitForSeconds(1);
    //             //ScoreCollection();
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

    //     public void ResetBat()
    //     {
    //         updater.batHp = 1f;
    //     }
}
