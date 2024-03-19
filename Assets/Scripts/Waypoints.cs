using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static List<Transform> waypoints;
    

    void Awake ()
    {
        waypoints = new List<Transform>();
        foreach (Transform waypoint in transform)
        {
            waypoints.Add(waypoint);
        }
    }

}
