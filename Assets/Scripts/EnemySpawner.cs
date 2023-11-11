// using System.Collections;
// using UnityEngine;

// public class EnemySpawner : MonoBehaviour
// {
//     [SerializeField]
//     private GameObject swarmerPrefab;
//     [SerializeField]
//     private GameObject bigSwarmerPrefab;

//     [SerializeField]
//     private int totalSwarmerEnemies = 10;
//     [SerializeField]
//     private float swarmerInterval = 2.5f;

//     [SerializeField]
//     private int totalBigSwarmerEnemies = 5;
//     [SerializeField]
//     private float bigSwarmerInterval = 5f;

//     private int swarmerCount = 0;
//     private int bigSwarmerCount = 0;

//     private void Start()
//     {
//         StartCoroutine(SpawnWave());
//     }

//     private IEnumerator SpawnWave()
//     {
//         while (swarmerCount < totalSwarmerEnemies || bigSwarmerCount < totalBigSwarmerEnemies)
//         {
//             if (swarmerCount < totalSwarmerEnemies)
//             {
//                 SpawnEnemy(swarmerPrefab);
//                 swarmerCount++;
//             }

//             if (bigSwarmerCount < totalBigSwarmerEnemies)
//             {
//                 SpawnEnemy(bigSwarmerPrefab);
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

//     private void SpawnEnemy(GameObject enemyPrefab)
//     {
//         Vector3 spawnPosition = GetRandomSpawnPosition();
//         Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
//     }

//     private Vector3 GetRandomSpawnPosition()
//     {
//         return new Vector3(Random.Range(-6f, 6f), Random.Range(-6f, 6f), 0);
//     }
// }


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject swarmerPrefab;
    [SerializeField]
    private GameObject bigSwarmerPrefab;

    [SerializeField]
    private float swarmerInterval = 3.5f;
    [SerializeField]
    private float bigSwarmerInterval = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab));
        StartCoroutine(spawnEnemy(bigSwarmerInterval, bigSwarmerPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
*/

using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject swarmerPrefab;
    [SerializeField]
    private GameObject bigSwarmerPrefab;

    [SerializeField]
    private int totalSwarmerEnemies = 10;
    [SerializeField]
    private float swarmerInterval = 2.5f;

    [SerializeField]
    private int totalBigSwarmerEnemies = 5;
    [SerializeField]
    private float bigSwarmerInterval = 5f;

    private int swarmerCount = 0;
    private int bigSwarmerCount = 0;

    private void Start()
    {
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        while (swarmerCount < totalSwarmerEnemies || bigSwarmerCount < totalBigSwarmerEnemies)
        {
            if (swarmerCount < totalSwarmerEnemies)
            {
                SpawnEnemy(swarmerPrefab);
                swarmerCount++;
            }

            if (bigSwarmerCount < totalBigSwarmerEnemies)
            {
                SpawnEnemy(bigSwarmerPrefab);
                bigSwarmerCount++;
            }

            yield return new WaitForSeconds(swarmerInterval);
            yield return new WaitForSeconds(bigSwarmerInterval);
        }

        // Reset counts for the next wave.
        // swarmerCount = 0;
        // bigSwarmerCount = 0;

        // Wait for a delay before starting the next wave.
        yield return new WaitForSeconds(2.0f); // Adjust this time to control the gap between waves.

        // Start the next wave.
        StartCoroutine(SpawnWave());
    }

    private void SpawnEnemy(GameObject enemyPrefab)
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPosition;
        bool isPositionValid = false;

        // Define a maximum number of attempts to prevent an infinite loop
        int maxAttempts = 50;
        int attempts = 0;

        do
        {
            // Generate a random spawn position
            spawnPosition = new Vector3(Random.Range(-6f, 6f), Random.Range(-6f, 6f), 0);

            // Check if the spawn position is valid (not inside wall colliders)
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(spawnPosition, 0.5f); // Adjust the radius as needed
            isPositionValid = true;

            foreach (Collider2D collider in hitColliders)
            {
                if (collider.CompareTag("walls"))
                {
                    isPositionValid = false;
                    break;
                }
            }

            attempts++;
        } while (!isPositionValid && attempts < maxAttempts);

        if (attempts >= maxAttempts)
        {
            Debug.LogWarning("Unable to find a valid spawn position after multiple attempts.");
        }

        return spawnPosition;
    }
}

