using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;
using Unity.VisualScripting;
using System;

public class cat_movement : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 movement;
    private Rigidbody2D rb;
    public float speed = 0.2f;
    public Animator playerAnimator;
    public GameObject punchHitbox;
    Collider2D punchCollider;
    //public GameObject hitBox;

    public bool climb { get; set; }
    private float dirX, dirY;
    [SerializeField] AudioSource walkingSFX;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    [SerializeField] private TrailRenderer tr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        punchCollider = punchHitbox.GetComponent<Collider2D>();
    }
    private void Update()
    {
        if (isDashing)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();

        if (movement.x != 0 || movement.y != 0)
        {
            if (!walkingSFX.isPlaying)
            {
                walkingSFX.Play();
            }

            playerAnimator.SetFloat("xDir", movement.x);
            playerAnimator.SetFloat("yDir", movement.y);
            playerAnimator.SetBool("isWalking", true);

        }
        else
        {
            walkingSFX.Stop();
            playerAnimator.SetBool("isWalking", false);
        }


    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

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
    // void OnAttack()
    // {
    //     playerAnimator.SetTrigger("isAttacking");
    // }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
