using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    public float startHealth = 100f;

    private NavMeshAgent agent;
    
    private float health;
    
    public int moneyGain = 50;

    public GameObject deathEffect;

    [Header("Unity Stuff")] 
    public Image healthBar;

    [HideInInspector]
    private bool isDead = false;

    void Start()
    {
        health = startHealth;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = startSpeed;
    }
    
    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        
        PlayerStats.Money += moneyGain;
        
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnemiesAlive--;
        
        Destroy(gameObject);
    }

    public void Slow(float pct)
    {
        agent.speed = startSpeed * (1f - pct);
    }

}
