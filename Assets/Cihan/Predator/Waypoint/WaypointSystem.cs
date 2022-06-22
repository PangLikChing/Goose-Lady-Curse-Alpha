using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointSystem : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        UpdateDestination();
    }

    public void Update()
    {
        if (Vector3.Distance(transform.position, target) < 1f)
        {
            Waypoint();
        }

        UpdateDestination();
    }

    public void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    public void Waypoint()
    {
        waypointIndex++;

        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
}
