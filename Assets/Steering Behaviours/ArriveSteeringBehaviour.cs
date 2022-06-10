using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArriveSteeringBehaviour : SeekSteeringBehaviour
{
    public float SlowdownDistance = 1.0f;
    public float Deceleration = 2.5f;
    public float StoppingDistance = 0.1f;

    public override Vector3 CalculateForce()
    {
        //CheckMouseInput();
        return DetermineDesiredArriveForce();
    }

    protected Vector3 DetermineDesiredArriveForce()
    {
        Vector3 toTarget = target - transform.position;
        float distance = toTarget.magnitude;

        steeringAgent.reachedGoal = false;
        if (distance > SlowdownDistance)
        {
            return base.DetermineDesiredSeekForce();
        }
        else if (distance > StoppingDistance && distance <= SlowdownDistance)
        {
            toTarget.Normalize();

            float speed = distance / Deceleration;
            speed = (speed < steeringAgent.maxSpeed ? speed : steeringAgent.maxSpeed);

            speed = speed / distance;
            desiredForce = toTarget * speed;
            return desiredForce - steeringAgent.velocity;
        }

        steeringAgent.reachedGoal = true;
        return Vector3.zero;
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        DebugExtension.DebugCircle(target, Vector3.up, Color.red, SlowdownDistance);
        DebugExtension.DebugCircle(target, Vector3.up, Color.blue, StoppingDistance);
    }

}
