using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 direction;
    private Animator playerAnimator;

    //private Vector3 respawnPosition;
    public Transform respawnPoint;

    public GameObject player;
    public GameObject[] keyPrefab;
    public treat_counter tc;        // manages the treat counter script -deb
    //public Gate openGate;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        takeInput();
    }

    private void takeInput()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }

        if (transform.position.y >= 5)
        {
            transform.position = new Vector3(transform.position.x, 5, 0);
        }
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
