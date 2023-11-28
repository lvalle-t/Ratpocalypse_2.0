using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rat_king_projectile : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;
    public float destroyDistance = 3f;
    private Animator animator;
    public enum states { traveling, popped };
    private states state;

    public PolygonCollider2D polygonCollider;
    public CircleCollider2D circleCollider;

    public float attackDamage = 0.02f;

    public float projectileLifeTime = 4f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        animator = GetComponent<Animator>();
        state = states.traveling;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (state == states.popped)
        {
            projectileLifeTime -= Time.deltaTime;
            polygonCollider.enabled = false;
            circleCollider.enabled = true;
            if (projectileLifeTime <= 0)
            {
                DestroyProjectile();
            }
        }
        if (state == states.traveling)
        {
            if (Vector2.Distance(transform.position, target) < destroyDistance)
            {
                state = states.popped;
                animator.Play("rat_king_projectile_popup", 0, .9f);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (state == states.popped)
        {
            if (other != null)
            {
                if (other.gameObject.tag == "Player")
                {
                    other.GetComponent<PlayerHealth>().EnemyDamage(attackDamage);

                }
            }
        }
        if (state == states.traveling)
        {
            if (other.CompareTag("Player"))
            {
                state = states.popped;
                animator.Play("rat_king_projectile_popup", 0, .9f);
            }
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
