using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alligator_Controller : MonoBehaviour
{
    private AIPath aiPath; // Reference to the AIPath component.
    public Rigidbody2D gatorRb;
    public Transform player;
    public Animator gatorAnimator;

    public float attackRange = .1f;
    public float damage;

    public bool isFlipped = false;
    public bool isDead = false;

    public Alligator_healthBar healthBar;
    public float damaged = 0.2f;
    public GameObject[] itemDrops;

    public GameObject antMobs;
    public GameObject batMobs;

    public GameObject[] antPrefab;
    public GameObject[] batPrefab;

    private bool breakTime;


    void Start()
    {
        gatorRb = GetComponent<Rigidbody2D>();
        gatorAnimator = GetComponent<Animator>();

        // Check if AIPath component is already attached, if not, add it.
        aiPath = GetComponent<AIPath>();
        if (aiPath == null)
        {
            aiPath = gameObject.AddComponent<AIPath>();
        }

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the AIPath's destination to follow the player.
        aiPath.destination = player.position;
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(player.position, gatorRb.position) <= attackRange)
        {
            gatorAnimator.SetBool("Alligator_bite", true);             // Start attacking when the player is within attack range
        }
        else if (Vector2.Distance(player.position, -gatorRb.position) <= attackRange)
        {
            gatorAnimator.SetBool("Alligator_tail_swipe", true);
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
        else if (updater.alligatorHp == 4f && breakTime == true)
        {
            SpawnAnts();
        }
        else if (updater.alligatorHp == 6f && breakTime == true)
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
            Instantiate(antPrefab[Random.Range(0, antPrefab.Length)], new Vector3(Random.Range(-91, 55), Random.Range(-82, -40), 0), Quaternion.identity);
        }
    }

    public void SpawnBats()
    {
        batMobs.SetActive(true);
        int enemiesThisRow = 10;

        for (int i = 0; i < enemiesThisRow; i++)
        {
            Instantiate(batPrefab[Random.Range(0, batPrefab.Length)], new Vector3(Random.Range(-91, 55), Random.Range(-82, -40), 0), Quaternion.identity);
        }

        Invoke("Underground", 1);
    }

    private void ItemDrop()
    {
        for (int i = 0; i < itemDrops.Length; i++)
        {
            Instantiate(itemDrops[i], transform.position, Quaternion.identity);
        }
    }
}


