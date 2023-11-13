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
        //aiPath.destination = player.position;
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
