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
    [Header("Pause Menu Objects")]
    public GameObject PausePanel;
    public GameObject catPlayer;
    [Header("Dash Settings")]
    [SerializeField] float dashSpeed = 10f;
    [SerializeField] float dashDuration = 1f;
    [SerializeField] float dashCooldown = 1f;
    bool isDashing;
    bool canDash;
    [SerializeField] private TrailRenderer tr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        punchCollider = punchHitbox.GetComponent<Collider2D>();
        canDash = true;
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
    public void OnPause()
    {
        if (!PausePanel.activeSelf)
        {
            PausePanel.SetActive(true);
            catPlayer.SetActive(false);
            Time.timeScale = 0;
        }
        else{
            PausePanel.SetActive(false);
            catPlayer.SetActive(true);
            Time.timeScale = 1;
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
        rb.velocity = new Vector2(movement.x * dashSpeed, movement.y * dashSpeed);
        tr.emitting = true;
        //rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        yield return new WaitForSeconds(dashDuration);
        tr.emitting = true;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;

    }
}
