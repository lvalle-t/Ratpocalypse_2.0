using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonar : MonoBehaviour
{
    public Animator sonarAnimator;
    public float speed;
    private Transform player;
    private Vector2 target;
    public float destroyDistance = 0.1f;

    public bool isShooting = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sonarAnimator = GetComponent<Animator>();
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
        if (Vector2.Distance(transform.position, target) < destroyDistance)
        {
            isShooting = false;
            sonarAnimator.SetBool("isShooting", isShooting);
            DestroyProjectile();
        }
    }

    private void FixedUpdate()
    {
        if (!isShooting)
        {
            isShooting = true;
            sonarAnimator.SetBool("isShooting", isShooting);
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isShooting = false;
            sonarAnimator.SetBool("isShooting", isShooting);
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
