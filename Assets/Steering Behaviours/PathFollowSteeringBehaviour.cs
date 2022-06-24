using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFollowSteeringBehaviour : ArriveSteeringBehaviour
{
    public float WaypointDistance = 0.5f;

    private int currentWaypointIndex = 0;
    private NavMeshPath path;

    private void Awake()
    {
        path = new NavMeshPath();
        target = transform.position;
    }

    public override Vector3 CalculateForce()
    {
        //if (CheckMouseInput() == true)
        //{
        //    currentWaypointIndex = 0;
        //    NavMesh.CalculatePath(transform.position, target, NavMesh.AllAreas, path);
        //    if (path.corners.Length > 0)
        //    {
        //        target = path.corners[currentWaypointIndex];
        //    }
        //    else
        //    {
        //        target = transform.position;
        //    }
        //}

        if (currentWaypointIndex != path.corners.Length && 
            (target - transform.position).magnitude < WaypointDistance)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex < path.corners.Length)
            {
                target = path.corners[currentWaypointIndex];
            }
        }

        return base.DetermineDesiredArriveForce();
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        if (path != null)
        {
            for(int i = 0; i < path.corners.Length - 1; i++)
            {
                Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.black);
                DebugExtension.DebugWireSphere(path.corners[i], Color.black, WaypointDistance);
            }
        }
    }
}
