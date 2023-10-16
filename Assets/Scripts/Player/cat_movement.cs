using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cat_movement : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 movement;
    private Rigidbody2D rb;
    public float speed = 2;
    private Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("xDir", movement.x);
            animator.SetFloat("yDir", movement.y);
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }


    }
    private void FixedUpdate()
    {
        //variant 1 for movement
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        //variant 2 for movement
        //if(movement.x != 0 || movement.y != 0){
        //rb.velocity = movement * speed;
        //}
        //variant 3 for movement
        //rb.AddForce(movement * speed);
    }
}
