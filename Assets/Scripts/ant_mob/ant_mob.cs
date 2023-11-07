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
using Pathfinding;

public class ant_mob : MonoBehaviour
{
    private AIPath aiPath; // Reference to the AIPath component.
    public GameObject fire_breath;
    private Transform player;

    public float startTimeBtwShots;
    private float timeBtwShots;

    void Start()
    {
        // Check if AIPath component is already attached, if not, add it.
        aiPath = GetComponent<AIPath>();
        if (aiPath == null)
        {
            aiPath = gameObject.AddComponent<AIPath>();
        }

        player = GameObject.FindGameObjectWithTag("Player").transform; // Assuming your player has the "Player" tag.
        timeBtwShots = startTimeBtwShots;

        // Set the AIPath's destination to the player's position.
        aiPath.destination = player.position;
    }

    void Update()
    {
        // Update the AIPath's destination to follow the player.
        aiPath.destination = player.position;

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
