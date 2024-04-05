using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    private Enemy enemy;

    void Start()
    {
        target = Waypoints.waypoints[wavepointIndex];
        enemy = GetComponent<Enemy>();
        
    }
    
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * (enemy.speed * Time.deltaTime), Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;
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
        Destroy(gameObject);
    }
}
