using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Alligator_Controller : MonoBehaviour
{
    public Rigidbody2D gatorRb;
    public Animator gatorAnimator;

    public float attackRange;
    public float damage;
    public Alligator_Attack gatorAttack;


    public Alligator_healthBar healthBar;
    public GameObject[] itemDrops;

    public GameObject enemy1Mobs;
    public GameObject[] enemy1Prefab;
    public float enemy1MinX;
    public float enemy1MaxX;
    public float enemy1MinY;
    public float enemy1MaxY;

    public GameObject enemy2Mobs;
    public GameObject[] enemy2Prefab;
    public float enemy2MinX;
    public float enemy2MaxX;
    public float enemy2MinY;
    public float enemy2MaxY;

    public float stoppingDistance; // tells mole how far it can go before it will overlap

    public Transform player;

    private bool helpTime;
    public bool isDead = false;

    private AIPath aiPath;
    int expAmount = 100;


    void Start()
    {
        gatorRb = GetComponent<Rigidbody2D>();
        gatorAnimator = GetComponent<Animator>();


        if (aiPath == null)
        {
            aiPath = gameObject.AddComponent<AIPath>();
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        aiPath.orientation = OrientationMode.YAxisForward;
        aiPath.destination = player.position;
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(player.position, gatorRb.position) <= attackRange)
        {
            gatorAttack.BiteAttack();
        }
        else if (Vector2.Distance(player.position, gatorRb.position) >= attackRange)
        {
            gatorAttack.ExitAttack();
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
            ExperienceManager.Instance.AddExperience(expAmount);
            
        }
        healthBar.UpdateHealth(updater.alligatorHp);
    }

    IEnumerator SetAlligatorObject()
    {
        helpTime = true;
        if (updater.alligatorHp <= 0f)
        {
            isDead = true;
            ItemDrop();
            Destroy(gameObject);
        }
        else if (updater.alligatorHp == 18f && helpTime == true)
        {
            SpawnAnts();
        }
        else if (updater.alligatorHp == 36f && helpTime == true)
        {
            SpawnBats();
        }

        yield return helpTime = false;
    }

    public void SpawnAnts()
    {
        enemy1Mobs.SetActive(true);
        int enemiesThisRow = 8;

        for (int i = 0; i < enemiesThisRow; i++)
        {
            Instantiate(enemy1Prefab[Random.Range(0, enemy1Prefab.Length)], new Vector3(Random.Range(enemy1MinX, enemy1MaxX), Random.Range(enemy1MinY, enemy1MaxY), 0), Quaternion.identity);
        }
    }

    public void SpawnBats()
    {
        enemy2Mobs.SetActive(true);
        int enemiesThisRow = 10;

        for (int i = 0; i < enemiesThisRow; i++)
        {
            Instantiate(enemy2Prefab[Random.Range(0, enemy2Prefab.Length)], new Vector3(Random.Range(enemy2MinX, enemy2MaxX), Random.Range(enemy2MinY, enemy2MaxY), 0), Quaternion.identity);
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


