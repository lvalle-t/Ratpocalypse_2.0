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

        if (transform.position.y >= 5)
        {
            transform.position = new Vector3(transform.position.x, 5, 0);
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
