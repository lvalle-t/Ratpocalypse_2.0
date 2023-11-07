using System.Collections;
using UnityEngine;
using Pathfinding;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject swarmerPrefab;
    [SerializeField]
    private GameObject bigSwarmerPrefab;

    [SerializeField]
    private int totalSwarmerEnemies = 10; // Total swarmer enemies for the wave.
    [SerializeField]
    private float swarmerInterval = 2.5f;

    [SerializeField]
    private int totalBigSwarmerEnemies = 5; // Total big swarmer enemies for the wave.
    [SerializeField]
    private float bigSwarmerInterval = 5f;

    private int swarmerCount = 0;
    private int bigSwarmerCount = 0;

    private Transform player; // Reference to the player's transform.
    private Transform parentObject; // Reference to the parent object.

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Assuming your player has the "Player" tag.
        parentObject = transform; // Set the parent object as the script's GameObject.
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        while (swarmerCount < totalSwarmerEnemies || bigSwarmerCount < totalBigSwarmerEnemies)
        {
            if (swarmerCount < totalSwarmerEnemies)
            {
                GameObject swarmer = Instantiate(swarmerPrefab, GetRandomSpawnPosition(), Quaternion.identity);
                SetupAIPath(swarmer); // Set up AIPath and AIDestination.
                SetParent(swarmer); // Set the parent of the spawned mob.
                swarmerCount++;
            }

            if (bigSwarmerCount < totalBigSwarmerEnemies)
            {
                GameObject bigSwarmer = Instantiate(bigSwarmerPrefab, GetRandomSpawnPosition(), Quaternion.identity);
                SetupAIPath(bigSwarmer); // Set up AIPath and AIDestination.
                SetParent(bigSwarmer); // Set the parent of the spawned mob.
                bigSwarmerCount++;
            }

            yield return new WaitForSeconds(swarmerInterval);
            yield return new WaitForSeconds(bigSwarmerInterval);
        }

        // Reset counts for the next wave.
        swarmerCount = 0;
        bigSwarmerCount = 0;

        // Wait for a delay before starting the next wave.
        yield return new WaitForSeconds(0.0f); // Adjust this time to control the gap between waves.

        // Start the next wave.
        StartCoroutine(SpawnWave());
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(Random.Range(-5f, 5f), Random.Range(-4f, 4f), 0);
    }

    private void SetupAIPath(GameObject enemy)
    {
        if (enemy != null) // Check if the enemy is null before accessing it.
        {
            AIPath aiPath = enemy.GetComponent<AIPath>();
            if (aiPath != null)
            {
                //aiPath.orientation = OrientationMode.YAxisForward;
                aiPath.destination = player.position;
            }
        }
    }

    private void SetParent(GameObject enemy)
    {
        if (enemy != null) // Check if the enemy is null before accessing it.
        {
            enemy.transform.parent = parentObject;
        }
        else{
            Debug.LogError("Enemy GameObject is null in SetParent.");
        }
    }
}

