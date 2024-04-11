using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;
    
    public Transform spawnPoint;
    public float timeBetweenWaves = 20f;
    public TextMeshProUGUI waveCountdownText;

    public GameManager gameManager;

    private float countdown = 2f;
    private int waveNumber = 0;
    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }
        
        if (waveNumber >= waves.Length)
        {
            Debug.Log("Level Completed!");
            Debug.Log(PlayerStats.Rounds);
            gameManager.WinLevel();
            this.enabled = false;
            return;
        }
        
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveNumber];

        EnemiesAlive = wave.count;
        
        Debug.Log("Wave incoming!");
        for (int i = 0; i < wave.count; ++i)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        
        waveNumber++;
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
