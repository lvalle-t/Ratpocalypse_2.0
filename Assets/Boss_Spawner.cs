using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    [SerializeField] private int totalBossCount = 1;

    public float areaX;
    public float areaY;

    private int bossCount = 0;

    private void Start()
    {
        SpawnBoss();
    }

    private void SpawnBoss()
    {
        if (bossCount < totalBossCount)
        {
            Instantiate(boss, new Vector3(areaX, areaY, 0), Quaternion.identity);
            bossCount = totalBossCount;
        }
    }
}
