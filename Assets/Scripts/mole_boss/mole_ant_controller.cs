using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

//**********************************************************************************
// This Script Was Created Using the Following Resources:
//    - https://pll.harvard.edu/course/cs50s-introduction-game-development
//    - https://docs.unity3d.com/Manual/index.html
//    - Text MeshPro Unity Sample Scripts
//**************************************************************************deb*****

public class mole_ant_controller : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;

    public Transform player;
    public AntHP healthBar;
    private Vector3 direction;
    private Vector2 move;

    public GameObject fireBreath;
    public Transform fireBreathPos;
    public float startTimeBtwShots;
    private float timeBtwShots;

    private Rigidbody2D antRb;

    public GameObject[] itemDrop;

    public bool isFlipped = false;
    int expAmount = 100;

    void Start()
    {
        antRb = GetComponent<Rigidbody2D>();
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
        Vector2 direction = (target - antRb.position).normalized;
        Vector2 newPos = antRb.position;


        if (Vector2.Distance(player.position, antRb.position) > stoppingDistance)
        {
            newPos = antRb.position + direction * speed * Time.fixedDeltaTime; // Move towards the player if they are outside the stopping distance
        }
        antRb.MovePosition(newPos);


        if (timeBtwShots <= 0)
        {
            CastFireBreath();
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
            isFlipped = true;
        }
        else if (transform.position.x > player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
    }

    void CastFireBreath()
    {
        Instantiate(fireBreath, fireBreathPos.position, Quaternion.identity);
    }

    public void TakeDamage(int damage)
    {
        if ((updater.antHp - damage) > 0f)
        {
            updater.antHp -= damage;
        }
        else
        {
            updater.antHp = 0f;
            UpdateAnt();
            ExperienceManager.Instance.AddExperience(expAmount);
        }
        healthBar.UpdateHealth(updater.antHp);
    }

    public void UpdateAnt()
    {
        Destroy(gameObject);

        for (int i = 0; i < itemDrop.Length; i++)
        {
            Instantiate(itemDrop[i], transform.position, Quaternion.identity);
        }
    }
    public void ResetAnt()
    {
        updater.antHp = 1f;
    }
}

