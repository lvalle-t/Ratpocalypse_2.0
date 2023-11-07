using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class snake_controller : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;
    public int scoreNum = 0;        // adds to the scoreTxt count - deb

    public snake_healthBar healthBar;
    public float damaged = 0.2f;
    public GameObject[] itemDrops;


    // private AIPath aiPath;

    void Start()
    {
        // aiPath = GetComponent<AIPath>();
        // if (aiPath == null)
        // {
        //     aiPath = gameObject.AddComponent<AIPath>();
        // }
        //rb = GetComponent<Rigidbody2D>();
        //batAnimator = GetComponent<Animator>();
        // player = GameObject.FindGameObjectWithTag("Player").transform;
        // aiPath.destination = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        //aiPath.destination = player.position;
    }

    private void FixedUpdate()
    {
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AttackBox"))
        {
            TakeDamage(damaged);
        }
    }

    void TakeDamage(float damage)
    {
        if ((updater.snakeHp - damage) > 0f)
        {
            updater.snakeHp -= damage;
        }
        else
        {
            updater.snakeHp = 0f;
            ScoreCollection();
        }
        healthBar.UpdateHealth(updater.snakeHp);
    }
    public void ScoreCollection()
    {
        scoreNum = updater.scoreCount += 100;                 // updates the score counter
        Destroy(gameObject);
        ItemDrop();
    }

    private void ItemDrop()
    {
        for (int i = 0; i < itemDrops.Length; i++)
        {
            Instantiate(itemDrops[i], transform.position, Quaternion.identity);
        }
    }
}


