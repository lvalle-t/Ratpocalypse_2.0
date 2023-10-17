using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// https://youtu.be/SELTWo1XZ0c?si=vGJsgkCW5fuqYPeU

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


using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject swarmerOriginalPrefab; // The original enemy prefab
    [SerializeField]
    private GameObject bigSwarmerOriginalPrefab; // The original enemy prefab

    [SerializeField]
    private float swarmerInterval = 3.5f;
    [SerializeField]
    private float bigSwarmerInterval = 10f;
    [SerializeField]
    public float totalTimeToSpawn = 60f; // Total time to spawn enemies in seconds.

    private float currentTime = 0f; // Current time elapsed.

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies(swarmerInterval, swarmerOriginalPrefab));
        StartCoroutine(SpawnEnemies(bigSwarmerInterval, bigSwarmerOriginalPrefab));
    }

    private IEnumerator SpawnEnemies(float interval, GameObject originalPrefab)
    {
        while (currentTime < totalTimeToSpawn)
        {
            yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(originalPrefab, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0), Quaternion.identity);
            currentTime += interval;
        }
    }

    // Add a method to stop spawning when needed.
    public void StopSpawning()
    {
        StopAllCoroutines();
    }
}

