// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;



// // https://youtu.be/SELTWo1XZ0c?si=vGJsgkCW5fuqYPeU

// public class EnemySpawner : MonoBehaviour
// {
//     [SerializeField]
//     private GameObject swarmerPrefab;
//     [SerializeField]
//     private GameObject bigSwarmerPrefab;

//     [SerializeField]
//     private float swarmerInterval = 3.5f;
//     [SerializeField]
//     private float bigSwarmerInterval = 10f;

//     // Start is called before the first frame update
//     void Start()
//     {
//         StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab));
//         StartCoroutine(spawnEnemy(bigSwarmerInterval, bigSwarmerPrefab));
//     }

//     private IEnumerator spawnEnemy(float interval, GameObject enemy)
//     {
//         yield return new WaitForSeconds(interval);
//         GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
//         StartCoroutine(spawnEnemy(interval, enemy));
//     }
// }

// public class Wave{
//     public string wa
// }

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EnemySpawner : MonoBehaviour
// {
//     [SerializeField]
//     private GameObject swarmerOriginalPrefab; // The original enemy prefab
//     [SerializeField]
//     private GameObject bigSwarmerOriginalPrefab; // The original enemy prefab

//     [SerializeField]
//     private float swarmerInterval = 3.5f;
//     [SerializeField]
//     private float bigSwarmerInterval = 10f;
//     [SerializeField]
//     public float totalTimeToSpawn = 60f; // Total time to spawn enemies in seconds.

//     private float currentTime = 0f; // Current time elapsed.

//     // Start is called before the first frame update
//     void Start()
//     {
//         StartCoroutine(SpawnEnemies(swarmerInterval, swarmerOriginalPrefab));
//         StartCoroutine(SpawnEnemies(bigSwarmerInterval, bigSwarmerOriginalPrefab));
//     }

//     private IEnumerator SpawnEnemies(float interval, GameObject originalPrefab)
//     {
//         while (currentTime < totalTimeToSpawn)
//         {
//             yield return new WaitForSeconds(interval);
//             GameObject newEnemy = Instantiate(originalPrefab, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0), Quaternion.identity);
//             currentTime += interval;
//         }
//     }

//     // Add a method to stop spawning when needed.
//     public void StopSpawning()
//     {
//         StopAllCoroutines();
//     }
// }


// using System.Collections;
// using UnityEngine;

// public class EnemySpawner : MonoBehaviour
// {
//     [SerializeField]
//     private GameObject swarmerPrefab;
//     [SerializeField]
//     private GameObject bigSwarmerPrefab;

//     [SerializeField]
//     private int totalSwarmerEnemies = 10; // Total swarmer enemies for the wave.
//     [SerializeField]
//     private float swarmerInterval = 2.5f;

//     [SerializeField]
//     private int totalBigSwarmerEnemies = 5; // Total big swarmer enemies for the wave.
//     [SerializeField]
//     private float bigSwarmerInterval = 5f;

//     private int swarmerCount = 0;
//     private int bigSwarmerCount = 0;

//     // Start is called before the first frame update
//     void Start()
//     {
//         StartCoroutine(SpawnWave());
//     }

//     private IEnumerator SpawnWave()
//     {
//         while (swarmerCount < totalSwarmerEnemies || bigSwarmerCount < totalBigSwarmerEnemies)
//         {
//             if (swarmerCount < totalSwarmerEnemies)
//             {
//                 Instantiate(swarmerPrefab, GetRandomSpawnPosition(), Quaternion.identity);
//                 swarmerCount++;
//             }

//             if (bigSwarmerCount < totalBigSwarmerEnemies)
//             {
//                 Instantiate(bigSwarmerPrefab, GetRandomSpawnPosition(), Quaternion.identity);
//                 bigSwarmerCount++;
//             }

//             yield return new WaitForSeconds(swarmerInterval);
//             yield return new WaitForSeconds(bigSwarmerInterval);
//         }

//         // Reset counts for the next wave.
//         swarmerCount = 0;
//         bigSwarmerCount = 0;

//         // Wait for a delay before starting the next wave.
//         yield return new WaitForSeconds(0.0f); // Adjust this time to control the gap between waves.

//         // Start the next wave.
//         StartCoroutine(SpawnWave());
//     }

//     private Vector3 GetRandomSpawnPosition()
//     {
//         return new Vector3(Random.Range(-5f, 5f), Random.Range(-4f, 4f), 0);
//     }
// }

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
        AIPath aiPath = enemy.GetComponent<AIPath>();
        if (aiPath != null)
        {
            aiPath.destination = player.position; // Set the player's position as the destination for AIPath.
        }
    }

    private void SetParent(GameObject enemy)
    {
        enemy.transform.parent = parentObject; // Set the parent of the spawned mob to the parent object.
    }
}

