using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//**********************************************************************************
// This Script Was Created Using the Following Resources:
//    - https://pll.harvard.edu/course/cs50s-introduction-game-development
//    - https://docs.unity3d.com/Manual/index.html
//    - Text MeshPro Unity Sample Scripts
//**************************************************************************deb*****

public class mole_bat_controller : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float attackRange;

    public Transform player;
    private Vector3 direction;
    private Vector2 move;

    public MoleBatHp healthBar;

    public GameObject sonarFire;
    public Transform sonarFirePos;
    public float startTimeBtwShots;
    private float timeBtwShots;

    private Rigidbody2D batRb;
    public Animator batAnimator;
    public GameObject[] itemDrop;

    public bool isFlipped = false;
    int expAmount = 100;

    void Start()
    {
        batRb = GetComponent<Rigidbody2D>();
        batAnimator = GetComponent<Animator>();
        batAnimator.SetBool("isAttacking", false);
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);    // playerHit.transform.position);

        direction = player.position - transform.position;
        direction.Normalize();
        move = direction;
    }
    private void FixedUpdate()
    {
        Follow(move);

        Vector2 target = new Vector2(player.position.x, player.position.y);
        Vector2 direction = (target - batRb.position).normalized;
        Vector2 newPos = batRb.position;

        if (Vector2.Distance(player.position, batRb.position) <= attackRange)
        {
            batAnimator.SetBool("isAttacking", true);            // Start attacking when the player is within attack range
        }
        else if (Vector2.Distance(player.position, batRb.position) > stoppingDistance)
        {
            newPos = batRb.position + direction * speed * Time.fixedDeltaTime; // Move towards the player if they are outside the stopping distance
        }
        batRb.MovePosition(newPos);


        if (timeBtwShots <= 0)
        {
            CastSonar();
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

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

    void CastSonar()
    {
        Instantiate(sonarFire, sonarFirePos.position, Quaternion.identity);
    }

    public void TakeDamage(int damage)
    {
        if ((updater.batHp - damage) > 0f)
        {
            updater.batHp -= damage;
        }
        else
        {
            updater.batHp = 0f;
            UpdateBat();
            ExperienceManager.Instance.AddExperience(expAmount);
        }
        healthBar.UpdateHealth(updater.batHp);
    }

    public void UpdateBat()
    {
        Destroy(gameObject);

        for (int i = 0; i < itemDrop.Length; i++)
        {
            Instantiate(itemDrop[i], transform.position, Quaternion.identity);
        }
    }
    public void ResetAnt()
    {
        updater.batHp = 1f;
    }
}
