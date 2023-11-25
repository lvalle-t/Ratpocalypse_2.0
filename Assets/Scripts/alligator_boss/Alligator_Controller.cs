using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alligator_Controller : MonoBehaviour
{
    public Rigidbody2D gatorRb;
    public Transform player;
    public Animator gatorAnimator;

    public float biteAttackRange = 4f;
    public float tailAttackRange = 8f;
    public float damage;
    public Alligator_Attack gatorAttack;


    public Alligator_healthBar healthBar;
    public GameObject[] itemDrops;

    public GameObject antMobs;
    public GameObject batMobs;

    public GameObject[] antPrefab;
    public GameObject[] batPrefab;

    private bool breakTime;
    private Vector3 direction;
    private Vector2 move;
    public bool isFlipped = false;
    public bool isDead = false;
    public float speed = 2f;
    public float stoppingDistance = .2f; // tells mole how far it can go before it will overlap


    void Start()
    {
        gatorRb = GetComponent<Rigidbody2D>();
        gatorAnimator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        isDead = false;
        direction = player.position - transform.position;
        direction.Normalize();
        move = direction;
    }

    private void FixedUpdate()
    {
        gatorAnimator.SetBool("isWalking", true);
        Follow(move);

        Vector2 target = new Vector2(player.position.x, player.position.y);
        Vector2 direction = (target - gatorRb.position).normalized;
        Vector2 newPos = gatorRb.position;

        if (Vector2.Distance(player.position, gatorRb.position) <= biteAttackRange)
        {
            gatorAnimator.SetTrigger("Alligator_bite");
            gatorAttack.BiteAttack();
        }
        else if (Vector2.Distance(player.position, gatorRb.position) <= tailAttackRange)
        {
            gatorAnimator.SetTrigger("Alligator_tail_swipe");
            gatorAttack.TailAttack();
        }
        else if (Vector2.Distance(player.position, gatorRb.position) > stoppingDistance)
        {
            newPos = gatorRb.position + direction * speed * Time.fixedDeltaTime; // Move towards the player if they are outside the stopping distance
        }

        gatorRb.MovePosition(newPos);
    }

    void Follow(Vector2 direction)
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x < player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x > player.position.x && !isFlipped)
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
            TakeDamage(damage);
        }
    }

    private void TakeDamage(float damage)
    {
        if ((updater.alligatorHp - damage) > 0f)
        {
            updater.alligatorHp -= damage;
            StartCoroutine(SetAlligatorObject());
        }
        else
        {
            updater.alligatorHp = 0f;
            StartCoroutine(SetAlligatorObject());
        }
        healthBar.UpdateHealth(updater.alligatorHp);
    }

    IEnumerator SetAlligatorObject()
    {
        breakTime = true;
        if (updater.alligatorHp <= 0f)
        {
            isDead = true;
            ItemDrop();
            Destroy(gameObject);
        }
        else if (updater.alligatorHp == 5f && breakTime == true)
        {
            SpawnAnts();
        }
        else if (updater.alligatorHp == 15f && breakTime == true)
        {
            SpawnBats();
        }

        yield return breakTime = false;
    }

    public void SpawnAnts()
    {
        antMobs.SetActive(true);
        int enemiesThisRow = 8;

        for (int i = 0; i < enemiesThisRow; i++)
        {
            Instantiate(antPrefab[Random.Range(0, antPrefab.Length)], new Vector3(Random.Range(-91, 55), Random.Range(-82, 9), 0), Quaternion.identity);
        }
    }

    public void SpawnBats()
    {
        batMobs.SetActive(true);
        int enemiesThisRow = 10;

        for (int i = 0; i < enemiesThisRow; i++)
        {
            Instantiate(batPrefab[Random.Range(0, batPrefab.Length)], new Vector3(Random.Range(-91, 55), Random.Range(-82, 9), 0), Quaternion.identity);
        }
    }

    private void ItemDrop()
    {
        for (int i = 0; i < itemDrops.Length; i++)
        {
            Instantiate(itemDrops[i], transform.position, Quaternion.identity);
        }
    }
}


