using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class cat_movement : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 movement;
    private Rigidbody2D rb;
    public float speed = 2;
    private Animator playerAnimator;
    public GameObject punchHitbox;
    Collider2D punchCollider;
    //public GameObject hitBox;

    public bool climb { get; set; }
    private float dirX, dirY;
    private bool isDead;
    private bool isOver;
    public GameManagerScript gameManager;

    private void Awake()
    {
        isDead = false;
        isOver = false;
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        punchCollider = punchHitbox.GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (climb)
        {
            dirY = Input.GetAxisRaw("Vertical") * speed;
        }
    }

    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
        if (movement.x != 0 || movement.y != 0)
        {
            playerAnimator.SetFloat("xDir", movement.x);
            playerAnimator.SetFloat("yDir", movement.y);
            playerAnimator.SetBool("isWalking", true);
        }
        else{
            playerAnimator.SetBool("isWalking", false);
        }


    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        if (climb && !isDead)
        {
            rb.isKinematic = true;
            rb.velocity = new Vector2(dirX, dirY);
        }
        else
        {
            rb.isKinematic = false;
            rb.velocity = new Vector2(dirX, rb.velocity.y);
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            punchHitbox.SetActive(true);
        }
        else { punchHitbox.SetActive(false); }

        SetAnima();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            climb = true;
        }
        else if (collision.gameObject.CompareTag("NextScene"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void OnAttack(){
        playerAnimator.SetTrigger("isAttacking");
    }

    public void SetAnima()
    {
        if ((updater.playerHp <= 0f) && !isDead)
        {
            isDead = true;
            playerAnimator.SetTrigger("isDead");
            gameManager.gameOver();
            Invoke("GameOverAnimation", 1);
        }
    }

    public void GameOverAnimation()
    {
        if (isDead == true && !isOver)
        {
            isDead = false;
            isOver = true;
            playerAnimator.SetTrigger("isOver");
        }
    }
}
