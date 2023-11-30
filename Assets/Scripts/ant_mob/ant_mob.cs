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

    void Start()
    {
        // Check if AIPath component is already attached, if not, add it.
        player = GameObject.FindGameObjectWithTag("Player").transform; // Assuming your player has the "Player" tag.
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        // Update the AIPath's destination to follow the player.
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
