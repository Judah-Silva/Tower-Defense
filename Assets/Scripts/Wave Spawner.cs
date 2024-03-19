using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 6f;
    public TextMeshProUGUI waveCountdownText;

    private float countdown = 2f;
    private int waveNumber = 0;
    void Update()
    {
        countdown -= Time.deltaTime;
        waveCountdownText.text = Math.Floor(countdown).ToString();
        
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        
        Debug.Log("Wave incoming!");
        for (int i = 0; i < waveNumber; ++i)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
