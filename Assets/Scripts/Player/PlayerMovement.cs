using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;
using Unity.VisualScripting;
using System;

public class PlayerMovement : MonoBehaviour
{
    public Animator playerAnimator;

    public Transform respawnPoint;

    public GameObject player;
    //public GameObject[] keyPrefab;
    public treat_counter tc;        // manages the treat counter script -deb

    public float moveSpeed = 8f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    private Vector2 moveInput;
    private List<RaycastHit2D> castCollision = new List<RaycastHit2D>();
    private Rigidbody2D rb;

    public bool climb { get; set; }
    private float dirX, dirY;
    [SerializeField] AudioSource walkingSFX;
    //[SerializeField] private TrailRenderer tr;


    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        takeInput();
    }

    public void FixedUpdate()
    {
        bool success = MovePlayer(moveInput);

        if (!success)
        {
            success = MovePlayer(new Vector2(moveInput.x, 0));

            if (!success)
            {
                success = MovePlayer(new Vector2(0, moveInput.y));
            }
        }
    }

    public bool MovePlayer(Vector2 direction)
    {
        int count = rb.Cast(direction, movementFilter, castCollision, moveSpeed * Time.fixedDeltaTime + collisionOffset);

        if (count == 0)
        {
            Vector2 moveVector = direction * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + moveVector);

            if (direction.x != 0 || direction.y != 0)
            {
                if (!walkingSFX.isPlaying)
                {
                    walkingSFX.Play();
                }

                playerAnimator.SetFloat("xDir", direction.x);
                playerAnimator.SetFloat("yDir", direction.y);
                playerAnimator.SetBool("isWalking", true);

            }
            else
            {
                walkingSFX.Stop();
                playerAnimator.SetBool("isWalking", false);
            }

            rb.MovePosition(rb.position + moveVector);
        return true;
        }
        else
        {
            foreach (RaycastHit2D hit in castCollision)
            {
                print(hit.ToString());
            }
            return false;
        }
    }

    private void takeInput()
    {
        moveInput = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            moveInput += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveInput += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveInput += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveInput += Vector2.right;
        }

        //if (transform.position.y >= 5)
        //{
        //    transform.position = new Vector3(transform.position.x, 5, 0);
        //}
    }

    private void SetAnimatorMovement(Vector2 direction)
    {
        playerAnimator.SetLayerWeight(1, 1);
        playerAnimator.SetFloat("xDir", direction.x);
        playerAnimator.SetFloat("yDir", direction.y);
        print(playerAnimator.GetFloat("xDir"));
    }

    private void OnTriggerEnter2D(Collider2D collision)         // detects collition -deb
    {
        if(collision.gameObject.CompareTag("Treats"))           // checks for assigned tag on object
        {
            tc.TreatCollection();                               // if it is a treat, go to treat counter
            Destroy(collision.gameObject);                      // destroy treat after counter updated 
        }
        else if (collision.gameObject.CompareTag("NextScene"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (collision.gameObject.CompareTag("PreviousScene"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else if (collision.gameObject.CompareTag("MausoleumExit"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            player.transform.position = respawnPoint.position;
        }
    }
}
