using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private Rigidbody2D rb;

    float moveHorizontal;
    float moveVertical;

    Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }
    void Update()
    {
        //https://www.youtube.com/watch?v=jkWVj28yWQ4
        // if(transform.position.y>=4){
        //     transform.position= new Vector3(transform.position.x,4,0);
        // }
        // else if(transform.position.y<=-10){
        //     transform.position= new Vector3(transform.position.x,-10,0);

        // }


        // Get input from arrow keys
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement direction
        movement = new Vector2(moveHorizontal, moveVertical);

        // Normalize movement to maintain constant speed in all directions
        movement.Normalize();

    }
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerMovement : MonoBehaviour {

// 	public CharacterController2D controller;
// 	public Animator animator;

// 	public float runSpeed = 40f;

// 	float horizontalMove = 0f;
// 	bool jump = false;
// 	bool crouch = false;

// 	// Update is called once per frame
// 	void Update () {

// 		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

// 		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

// 		if (Input.GetButtonDown("Jump"))
// 		{
// 			jump = true;
// 			animator.SetBool("IsJumping", true);
// 		}

// 		if (Input.GetButtonDown("Crouch"))
// 		{
// 			crouch = true;
// 		} else if (Input.GetButtonUp("Crouch"))
// 		{
// 			crouch = false;
// 		}

// 	}

// 	public void OnLanding ()
// 	{
// 		animator.SetBool("IsJumping", false);
// 	}

// 	public void OnCrouching (bool isCrouching)
// 	{
// 		animator.SetBool("IsCrouching", isCrouching);
// 	}

// 	void FixedUpdate ()
// 	{
// 		// Move our character
// 		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
// 		jump = false;
// 	}
// }