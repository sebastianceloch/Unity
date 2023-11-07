using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformWaypoint : MonoBehaviour
{
    public List<Vector3> waypoints = new List<Vector3>();
    public float speed = 5.0f;
    private int currentWaypointIndex = 0;
    private int direction = 1;


    void Update()
    {
        if (waypoints.Count == 0)
            return;

        Vector3 targetWaypoint = waypoints[currentWaypointIndex];
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, step);

        if (transform.position == targetWaypoint)
        {
            currentWaypointIndex += direction;

            if (currentWaypointIndex >= waypoints.Count || currentWaypointIndex < 0)
            {
                direction *= -1;
                currentWaypointIndex += direction;
            }
        }
    }
    public void AddWaypoint(Vector3 newWaypoint)
    {
        waypoints.Add(newWaypoint);
    }
}