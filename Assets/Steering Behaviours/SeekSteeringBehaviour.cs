using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekSteeringBehaviour : SteeringBehaviourBase
{
    protected Vector3 desiredForce;

    public override Vector3 CalculateForce()
    {
        //CheckMouseInput();
        return DetermineDesiredSeekForce();
    }

    protected Vector3 DetermineDesiredSeekForce()
    {
        desiredForce = (target - transform.position).normalized;
        desiredForce = desiredForce * steeringAgent.maxForce;
        desiredForce = (desiredForce - steeringAgent.velocity);
        return desiredForce;
    }

    protected virtual void OnDrawGizmos()
    {
        if (steeringAgent != null)
        {
            DebugExtension.DebugArrow(transform.position, desiredForce, Color.red);
            DebugExtension.DebugArrow(transform.position, steeringAgent.velocity, Color.blue);
            DebugExtension.DebugArrow(transform.position, (target - transform.position), Color.green);
            DebugExtension.DebugPoint(target, Color.green);
        }
    }
}
