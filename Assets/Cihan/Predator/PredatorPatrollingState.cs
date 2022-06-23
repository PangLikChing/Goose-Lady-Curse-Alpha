using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PredatorPatrollingState : PredatorBaseState
{
    [Header("Components")]

    NavMeshAgent agent;
    WaypointCollector waypointCollector;
    Transform[] waypoints;
    AvatarNormalMotion avatar;
    Predator predatorScript;

    [Header("Variables")]

    int waypointIndex;
    int pointsVisited;
    Vector3 target;
    float distPosition;
    

    public override void EnterState(Predator predator)
    {
        //Getting Components
        agent = predator.GetComponent<NavMeshAgent>();
        avatar = GameObject.FindObjectOfType<AvatarNormalMotion>();
        predatorScript = predator.GetComponent<Predator>();

        //Getting waypoints
        waypointCollector = predator.waypoints;
        waypoints = waypointCollector.allWaypoints;

        pointsVisited = 0;

        UpdateDestination();

        distPosition = Vector3.Distance(predatorScript.position.transform.position, predator.transform.position);

        Debug.Log("Patrolling State");

    }

    public override void UpdateState(Predator predator)
    {

        if (distPosition <= 5f)
        {
            //Debug.Log("Range");
            RangeCheck(predator);
        }
            
        

        //When get close to the waypoint, Update Destination

        if (Vector3.Distance(predator.transform.position, target) < 1f)
        {
            Waypoint();

        }

        UpdateDestination();

        //If enough points visited, switch to Idle State

        if (pointsVisited == 5)
        {
            predator.SwitchState(predator.predatorIdleState);
        }
    }

    public override void FixedUpdateState(Predator predator)
    {
        
    }

    //Update the destination, showing companion which point to go next

    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    //Next waypoint & reset waypoints when the loop is done

    void Waypoint()
    {
        waypointIndex++;
        pointsVisited++;

        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

    void RangeCheck(Predator predator)
    {
        if (Vector3.Distance(avatar.transform.position, predator.transform.position) < 8f)
        {
            Debug.Log("RangeCheck - Patrol");
            predator.SwitchState(predator.predatorAttackState);
        }

        
    }
}
