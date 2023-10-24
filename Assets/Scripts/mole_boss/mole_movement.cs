using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mole_movement : MonoBehaviour
{
    public mole_hp_slider healthBar;
    private float harm;

    public Transform player;
    public float speed = 20f;
    public float smoothMove = 0.1f;

    private Rigidbody2D rb;
    private Vector3 direction;
    private Vector2 move;
    //private float angle;
    private bool isFlipped = false;

    public int scoreNum = 0;        // adds to the scoreTxt count - deb


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = player.position - transform.position;
        //angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        direction.Normalize();
        move = direction;
    }
    private void FixedUpdate()
    {
        Follow(move);
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

        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Club"))
        {
            harm = -0.50f;
            if ((updater.moleHp + harm) > 0f)
            {
                updater.moleHp += harm;
            }
            else
            {
                updater.moleHp = 0f;
                UpdateMole();
                ScoreCollection();
            }
        }
    }
    public void UpdateMole()
    {
        Destroy(gameObject);
    }
    public void ResetMole()
    {
        updater.moleHp = 1f;
    }

    public void ScoreCollection()
    {
        scoreNum = updater.scoreCount += 50;                 // updates the score counter
    }
}
