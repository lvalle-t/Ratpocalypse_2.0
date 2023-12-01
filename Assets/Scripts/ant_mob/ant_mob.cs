// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Pathfinding;

// public class ant_mob : MonoBehaviour
// {
//     public GameObject fire_breath;
//     private Transform player;
//     public float startTimeBtwShots;
//     private float timeBtwShots;

//     void Start()
//     {
//         // Check if AIPath component is already attached, if not, add it.
//         player = GameObject.FindGameObjectWithTag("Player").transform; // Assuming your player has the "Player" tag.
//         timeBtwShots = startTimeBtwShots;
//     }

//     void Update()
//     {
//         // Update the AIPath's destination to follow the player.
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
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ant_mob : MonoBehaviour
{
    public GameObject fire_breath;
    private Transform player;
    public float startTimeBtwShots;
    private float timeBtwShots;

    private AIPath aiPath;  // Reference to the AIPath component

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;

        // Get the AIPath component
        aiPath = GetComponent<AIPath>();
        if (aiPath == null)
        {
            // If AIPath component is not found, add it
            aiPath = gameObject.AddComponent<AIPath>();
        }
    }

    void Update()
    {
        // Check if the AIPath component exists
        if (aiPath != null)
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
        //else
        //{
        //    Debug.LogError("AIPath component not found!");
        //}
    }
}
