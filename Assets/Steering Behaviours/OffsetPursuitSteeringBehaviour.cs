using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OffsetPursuitSteeringBehaviour : ArriveSteeringBehaviour
{
    public NavMeshAgent PursuitObject;
    public Vector3 Offset;

    private Vector3 worldSpaceOffset;
    private Vector3 offsetPosition;

    public override Vector3 CalculateForce()
    {
        if (PursuitObject != null)
        {
            worldSpaceOffset = PursuitObject.transform.rotation * Offset
                + PursuitObject.transform.position;

            offsetPosition = worldSpaceOffset - transform.position;
            float lookAheadTime = offsetPosition.magnitude / (steeringAgent.maxSpeed +
                PursuitObject.velocity.magnitude);

            target = worldSpaceOffset + PursuitObject.velocity * lookAheadTime;

            return base.CalculateForce();
        }

        return Vector3.zero;
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        DebugExtension.DebugArrow(transform.position, worldSpaceOffset, Color.yellow);
        DebugExtension.DebugCircle(worldSpaceOffset, Vector3.up, Color.cyan, 0.5f);
    }
}
