// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ant_mob : MonoBehaviour
// {
//     public float speed;
//     public float stoppingDistance;
//     private float timeBtwShots;
//     public float startTimeBtwShots;

//     public GameObject fire_breath;

//     //Rigidbody2D rb;
//     public Transform player;
//     public bool isFlipped = false;

//     void Start()
//     {
//         //rb = GetComponent<Rigidbody2D>();
//         player = GameObject.FindGameObjectWithTag("Player").transform;
//         timeBtwShots = startTimeBtwShots;
//     }

//     void Update()
//     {
//         LookAtPlayer();
//         if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
//         {

//             transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
//         }

//         if (timeBtwShots <= 0)
//         {
//             Instantiate(fire_breath, transform.position, Quaternion.identity);
//             timeBtwShots = startTimeBtwShots;
//         }
//         else
//         {
//             timeBtwShots -= Time.deltaTime;
//         }
//     }

//     public void LookAtPlayer()
//     {
//         Vector3 flipped = transform.localScale;
//         flipped.z *= -1f;

//         if (transform.position.x > player.position.x && isFlipped)
//         {
//             transform.localScale = flipped;
//             transform.Rotate(0f, 180f, 0f);
//             isFlipped = false;
//         }
//         else if (transform.position.x < player.position.x && !isFlipped)
//         {
//             transform.localScale = flipped;
//             transform.Rotate(0f, 180f, 0f);
//             isFlipped = true;
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ant_mob : MonoBehaviour
{
    // public float speed; 
    // public float stoppingDistance;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject fire_breath;
    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(fire_breath, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}