using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;
    private NavMeshAgent agent;

    private Enemy enemy;


    void Start()
    {
        target = Waypoints.waypoints[wavepointIndex];
        agent = GetComponent<NavMeshAgent>();
        enemy = GetComponent<Enemy>();
        Move();
    }
    
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
            Move();
        }
        agent.speed = enemy.startSpeed;
    }

    void Move()
    {
        agent.destination = target.position;
    }
    
    void GetNextWaypoint()
    {
        wavepointIndex++;
        if (wavepointIndex >= Waypoints.waypoints.Count)
        {
            EndPath();
            return;
        }
        else
        {
            target = Waypoints.waypoints[wavepointIndex];
        }
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
