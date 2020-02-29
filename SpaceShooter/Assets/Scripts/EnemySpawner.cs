﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    int StartingWave = 0;

    // Start is called before the first frame update
    void Start()
    {
        var currentWave = waveConfigs[StartingWave];
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0;enemyCount < waveConfig.GetNumberOfEnemies();enemyCount++)
        {
            Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWayPoints()[0].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }

}
