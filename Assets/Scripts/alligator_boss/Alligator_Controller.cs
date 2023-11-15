using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alligator_Controller : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;
    public int scoreNum = 0;        // adds to the scoreTxt count - deb

    public Alligator_healthBar healthBar;
    public float damaged = 0.2f;
    public GameObject[] itemDrops;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AttackBox"))
        {
            TakeDamage(damaged);
        }
    }

    void TakeDamage(float damage)
    {
        if ((updater.alligatorHp - damage) > 0f)
        {
            updater.alligatorHp -= damage;
        }
        else
        {
            updater.alligatorHp = 0f;
            ScoreCollection();
        }
        healthBar.UpdateHealth(updater.alligatorHp);
    }
    public void ScoreCollection()
    {
        //scoreNum = updater.scoreCount += 100;                 // updates the score counter
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


