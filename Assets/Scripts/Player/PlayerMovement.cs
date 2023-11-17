using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Vector2 direction;
    private Animator playerAnimator;

    private Vector3 respawnPosition;
    //public GameObject nextSceneCollider;

    public GameObject[] keyPrefab;
    public treat_counter tc;        // manages the treat counter script -deb
    public Gate openGate;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>(); 
        respawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        takeInput();
        Move();
    }

    private void FixedUpdate()
    {
        respawnPosition = transform.position;
        //nextSceneCollider.transform.position = new Vector2(transform.position.x, nextSceneCollider.transform.position.y);
    }

    private void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        if (direction.x != 0 || direction.y != 0)
        {
            SetAnimatorMovement(direction);
        }
        else
        {
            playerAnimator.SetLayerWeight(1, 0);
        }
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
            transform.position = respawnPosition;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else if (collision.gameObject.CompareTag("Gate"))
        {
            openGate.OpenGate();
        }
    }
}
