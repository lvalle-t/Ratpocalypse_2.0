using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//**********************************************************************************
// This Script Was Created Using the Following Resources:
//    - https://pll.harvard.edu/course/cs50s-introduction-game-development
//    - https://docs.unity3d.com/Manual/index.html
//    - Text MeshPro Unity Sample Scripts
//**************************************************************************deb*****

public class mole_movement : MonoBehaviour
{
    public mole_attack ma;              // mole attack manager
    public mole_hp_slider healthBar;
    public bool isDead;

    public Transform player;
    public float speed = 2f;
    public float stoppingDistance = .2f; // tells mole how far it can go before it will overlap
    public float attackRange = .1f;
    public float damage;

    private Rigidbody2D rb;
    private Vector3 direction;
    private Vector2 move;
    private bool isFlipped = false;

    public Animator moleAnimator;
    public GameObject[] itemDrops;

    public GameObject moleBoss;
    public GameObject moleDigging;
    public GameObject moleGoUnderground;
    public GameObject moleStayUnder;
    public GameObject moleComeOut;

    public GameObject[] antPrefab;
    public GameObject[] batPrefab;
    private bool breakTime;

    // Start is called before the first frame update
    void Start()
    {
        breakTime = false;
        rb = GetComponent<Rigidbody2D>();
        moleAnimator = GetComponent<Animator>();
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
        Follow(move);

        Vector2 target = new Vector2(player.position.x, player.position.y);
        Vector2 direction = (target - rb.position).normalized;
        Vector2 newPos = rb.position;

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            moleAnimator.SetTrigger("isAttacking");             // Start attacking when the player is within attack range
        }
        else if (Vector2.Distance(player.position, rb.position) > stoppingDistance)
        {
            newPos = rb.position + direction * speed * Time.fixedDeltaTime; // Move towards the player if they are outside the stopping distance
        }

        rb.MovePosition(newPos);
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
        if ((updater.moleHp - damage) > 0f)
        {
            updater.moleHp -= damage;
            StartCoroutine(SetMoleObject());
        }
        else
        {
            updater.moleHp = 0f;
            StartCoroutine(SetMoleObject());
        }
        healthBar.UpdateHealth(updater.moleHp);
    }

    IEnumerator SetMoleObject()
    {
        breakTime = true;
        if (updater.moleHp <= 0f)
        {
            isDead = true;
            moleAnimator.SetTrigger("isDead");

            yield return new WaitForSeconds(1);

            ScoreCollection();
        }
        else if (updater.moleHp == 4f && breakTime == true)
        {
            moleBoss.SetActive(false);
            moleDigging.SetActive(true);
            Invoke("SpawnBats", 1);
        }
        else if (updater.moleHp == 6f && breakTime == true)
        {
            moleBoss.SetActive(false);
            moleDigging.SetActive(true);
            Invoke("SpawnAnts", 1);
        }
        breakTime = false;
    }

    public void SpawnAnts()
    {
        int enemiesThisRow = 8;

        for (int i = 0; i < enemiesThisRow; i++)
        {
            Instantiate(antPrefab[Random.Range(0, antPrefab.Length)], new Vector3(Random.Range(-12, 12), Random.Range(-5, 8), 0), Quaternion.identity);
        }

        Invoke("Underground", 1);
    }

    public void SpawnBats()
    {
        int enemiesThisRow = 10;

        for (int i = 0; i < enemiesThisRow; i++)
        {
            Instantiate(batPrefab[Random.Range(0, batPrefab.Length)], new Vector3(Random.Range(-12, 16), Random.Range(8, 24), 0), Quaternion.identity);
        }

        Invoke("Underground", 1);
    }

    public void Underground()
    {
        moleDigging.SetActive(false);
        moleGoUnderground.SetActive(true);
        Invoke("StayUnder", 1);
    }

    public void StayUnder()
    {
        moleGoUnderground.SetActive(false);
        moleStayUnder.SetActive(true);
        Invoke("Aboveground", 6);
    }

    public void Aboveground()
    {
        moleStayUnder.SetActive(false);
        moleComeOut.SetActive(true);
        Invoke("StartFighting", 1);
    }

    public void StartFighting()
    {
        moleComeOut.SetActive(false);
        moleBoss.SetActive(true);
    }

    public void ScoreCollection()
    {
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

    public void ResetMole()
    {
        updater.moleHp = 10f;
    }








    //public mole_attack ma;              // mole attack manager
    //public mole_hp_slider healthBar;
    //public bool isDead;

    //public Transform player;
    //public float speed = 2f;
    //public float stoppingDistance = .2f; // tells mole how far it can go before it will overlap
    //public float attackRange = .1f;
    //public float damage;

    //private Rigidbody2D rb;
    //private Vector3 direction;
    //private Vector2 move;
    //private bool isFlipped = false;

    //public Animator moleAnimator;
    //public GameObject[] itemDrops;

    //public GameObject moleBoss;
    //public GameObject moleDigging;
    //public GameObject moleGoUnderground;
    //public GameObject moleStayUnder;
    //public GameObject moleComeOut;

    //public GameObject[] antPrefab;
    //public GameObject[] batPrefab;
    //private bool breakTime;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    breakTime = false;
    //    rb = GetComponent<Rigidbody2D>();
    //    moleAnimator = GetComponent<Animator>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    isDead = false;
    //    direction = player.position - transform.position;
    //    direction.Normalize();
    //    move = direction;
    //}
    //private void FixedUpdate()
    //{
    //    Follow(move);

    //    Vector2 target = new Vector2(player.position.x, player.position.y);
    //    Vector2 direction = (target - rb.position).normalized;
    //    Vector2 newPos = rb.position;

    //    if (Vector2.Distance(player.position, rb.position) <= attackRange)
    //    {
    //        moleAnimator.SetTrigger("isAttacking");             // Start attacking when the player is within attack range
    //    }
    //    else if (Vector2.Distance(player.position, rb.position) > stoppingDistance)
    //    {
    //        newPos = rb.position + direction * speed * Time.fixedDeltaTime; // Move towards the player if they are outside the stopping distance
    //    }

    //    rb.MovePosition(newPos);
    //}

    //void Follow(Vector2 direction)
    //{
    //    Vector3 flipped = transform.localScale;
    //    flipped.z *= -1f;

    //    if (transform.position.x < player.position.x && isFlipped)
    //    {
    //        transform.localScale = flipped;
    //        transform.Rotate(0f, 180f, 0f);
    //        isFlipped = false;
    //    }
    //    else if (transform.position.x > player.position.x && !isFlipped)
    //    {
    //        transform.localScale = flipped;
    //        transform.Rotate(0f, 180f, 0f);
    //        isFlipped = true;
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("AttackBox"))
    //    {
    //        TakeDamage(damage);
    //    }
    //}

    //private void TakeDamage(float damage)
    //{
    //    if ((updater.moleHp - damage) > 0f)
    //    {
    //        updater.moleHp -= damage;
    //        StartCoroutine(SetMoleObject());
    //    }
    //    else
    //    {
    //        updater.moleHp = 0f;
    //        StartCoroutine(SetMoleObject());
    //    }
    //    healthBar.UpdateHealth(updater.moleHp);
    //}

    //IEnumerator SetMoleObject()
    //{
    //    breakTime = true;
    //    if (updater.moleHp <= 0f)
    //    {
    //        isDead = true;
    //        moleAnimator.SetTrigger("isDead");

    //        yield return new WaitForSeconds(1);

    //        ScoreCollection();
    //    }
    //    else if (updater.moleHp <= 3f && breakTime == true)
    //    {
    //        moleBoss.SetActive(false);
    //        moleDigging.SetActive(true);
    //        Invoke("SpawnBats", 1);
    //    }
    //    else if (updater.moleHp <= 6f && breakTime == true)
    //    {
    //        moleBoss.SetActive(false);
    //        moleDigging.SetActive(true);
    //        Invoke("SpawnAnts", 1);
    //    }
    //    breakTime = false;
    //}

    //public void SpawnAnts()
    //{
    //    int enemiesThisRow = 6;

    //    for (int i = 0; i < enemiesThisRow; i++)
    //    {
    //        Instantiate(antPrefab[Random.Range(0, antPrefab.Length)], new Vector3(Random.Range(-12, 12), Random.Range(-5, 8), 0), Quaternion.identity);
    //    }

    //    Invoke("Underground", 1);
    //}

    //public void SpawnBats()
    //{
    //    int enemiesThisRow = 4;

    //    for (int i = 0; i < enemiesThisRow; i++)
    //    {
    //        Instantiate(batPrefab[Random.Range(0, batPrefab.Length)], new Vector3(Random.Range(-12, 16), Random.Range(8, 24), 0), Quaternion.identity);
    //    }

    //    Invoke("Underground", 1);
    //}

    //public void Underground()
    //{
    //    moleDigging.SetActive(false);
    //    moleGoUnderground.SetActive(true);
    //    Invoke("StayUnder", 1);
    //}

    //public void StayUnder()
    //{
    //    moleGoUnderground.SetActive(false);
    //    moleStayUnder.SetActive(true);
    //    Invoke("Aboveground", 6);
    //}

    //public void Aboveground()
    //{
    //    moleStayUnder.SetActive(false);
    //    moleComeOut.SetActive(true);
    //    Invoke("StartFighting", 1);
    //}

    //public void StartFighting()
    //{
    //    moleComeOut.SetActive(false);
    //    moleBoss.SetActive(true);
    //}

    //public void ScoreCollection()
    //{
    //    Destroy(gameObject);
    //    ItemDrop();
    //}

    //private void ItemDrop()
    //{
    //    for (int i = 0; i < itemDrops.Length; i++)
    //    {
    //        Instantiate(itemDrops[i], transform.position, Quaternion.identity);
    //    }
    //}

    ////public void ResetMole()
    ////{
    ////    updater.moleHp = 1f;
    ////}
}
