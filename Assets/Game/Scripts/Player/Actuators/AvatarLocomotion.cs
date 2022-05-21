using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AvatarLocomotion : MonoBehaviour
{
    [Tooltip("Angle Change Rate")]
    public float angularDampeningTime = 5.0f;
    [Tooltip("Angle Interpolation Threshold")]
    public float angularDeadZone = 10.0f;
#if UNITY_EDITOR
    [Tooltip("Avatar's actual speed")]
    public float agentSpeed;
#endif

    protected NavMeshAgent agent;
    protected Animator avatarAnimator;
    protected bool hasAnimator;

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        hasAnimator = TryGetComponent<Animator>(out avatarAnimator);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
#if UNITY_EDITOR
        agentSpeed = agent.velocity.magnitude;
#endif
        if (hasAnimator)
        {
            RotationControl();
        }
    }

    protected virtual void RotationControl()
    {
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            float angle = Vector3.Angle(transform.forward, agent.desiredVelocity);
            if (Mathf.Abs(angle) <= angularDeadZone)
            {
                transform.LookAt(transform.position + agent.desiredVelocity);
            }
            else
            {
                transform.rotation = Quaternion.Lerp(transform.rotation,
                                                     Quaternion.LookRotation(agent.desiredVelocity),
                                                     Time.deltaTime * angularDampeningTime);

            }

        }
    }

    public virtual void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }
}
