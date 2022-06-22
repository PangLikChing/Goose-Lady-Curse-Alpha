using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderSteeringBehaviour : SteeringBehaviourBase
{
    public float Distance = 2.0f;
    public float Radius = 1.0f;
    public float Jitter = 20.0f;
    public float timer;

    private Vector3 wanderTarget;

    void Start()
    {
        float theta = (float)Random.value * Mathf.PI * 2;
        wanderTarget = new Vector3(Radius * Mathf.Cos(theta),
                                   0.0f,
                                   Radius * Mathf.Sin(theta));
        target = wanderTarget;
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            float theta = (float)Random.value * Mathf.PI * 2;
            wanderTarget = new Vector3(Radius * Mathf.Cos(theta),
                                       0.0f,
                                       Radius * Mathf.Sin(theta));
            target = wanderTarget;
            timer = 0;
        }
    }

    public override Vector3 CalculateForce()
    {
        float jitterThisTimeSlice = Jitter * Time.deltaTime;

        wanderTarget = wanderTarget + new Vector3(Random.Range(-1.0f, 1.0f) * jitterThisTimeSlice,
                                                  0.0f,
                                                  Random.Range(-1.0f, 1.0f) * jitterThisTimeSlice);
        wanderTarget.Normalize();
        wanderTarget *= Radius;

        target = wanderTarget + Vector3.forward * Distance;
        target = steeringAgent.transform.rotation * target + steeringAgent.transform.position;

        Vector3 wanderForce = (target - steeringAgent.transform.position).normalized;
        return wanderForce *= steeringAgent.maxSpeed;
    }

    private void OnDrawGizmos()
    {
        if (steeringAgent != null)
        {
            Vector3 circleCenter = (steeringAgent.transform.rotation * (Vector3.forward * Distance)) + steeringAgent.transform.position;
            DebugExtension.DrawArrow(transform.position, steeringAgent.velocity, Color.black);
            Debug.DrawLine(circleCenter, target, Color.yellow);
            Debug.DrawLine(transform.position, target, Color.blue);
        }
        else
        {
            Vector3 circleCenter = (transform.rotation * (Vector3.forward * Distance)) + transform.position;
            DebugExtension.DrawCircle(circleCenter, Vector3.up, Color.red, Radius);
            Debug.DrawLine(transform.position, circleCenter, Color.yellow);
        }
    }
}
