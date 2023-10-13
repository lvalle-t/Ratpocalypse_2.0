// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerMovement: MonoBehaviour
// {
//     public float moveSpeed = 5.0f;

//     private Rigidbody2D rb;

//     float moveHorizontal;
//     float moveVertical;

//     Vector2 movement;

//     void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();

//     }

//     void FixedUpdate()
//     {
//         rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
//     }
//     void Update()
//     {
//         //https://www.youtube.com/watch?v=jkWVj28yWQ4
//         // if(transform.position.y>=4){
//         //     transform.position= new Vector3(transform.position.x,4,0);
//         // }
//         // else if(transform.position.y<=-10){
//         //     transform.position= new Vector3(transform.position.x,-10,0);

//         // }


//         // Get input from arrow keys
//         float moveHorizontal = Input.GetAxis("Horizontal");
//         float moveVertical = Input.GetAxis("Vertical");

//         // Calculate movement direction
//         movement = new Vector2(moveHorizontal, moveVertical);

//         // Normalize movement to maintain constant speed in all directions
//         movement.Normalize();

//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Vector2 direction;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        takeInput();
        Move();
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
            animator.SetLayerWeight(1, 0);
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
    }
    private void SetAnimatorMovement(Vector2 direction)
    {
        animator.SetLayerWeight(1, 1);
        animator.SetFloat("xDir", direction.x);
        animator.SetFloat("yDir", direction.y);
        print(animator.GetFloat("xDir"));
    }
}
