using Project.Build.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
[RequireComponent(typeof(NavMeshAgent))]
public class AvatarLocomotion : MonoBehaviour
{
    [Tooltip("Angle Change Rate")]
    public float angularDampeningTime = 5.0f;
    [Tooltip("Angle Interpolation Threshold")]
    public float angularDeadZone = 10.0f;
    [ReadOnly] 
    public Transform target;
    public event UnityAction PathCompleted = delegate { };
#if UNITY_EDITOR
    [ReadOnly]
    public float agentSpeed;
#endif

    protected NavMeshAgent agent;
    protected Animator avatarAnimator;
    protected bool hasAnimator;
    protected bool facingTarget;
    protected Vector3 targetDirection;


    public virtual void Start()
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

        if (agent.remainingDistance==0 && agent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            PathCompleted.Invoke();
        }

        if (hasAnimator)
        {
            RotationControl(agent.desiredVelocity);
        }
    }

    protected virtual void RotationControl(Vector3 facing)
    {

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            float angle = Vector3.Angle(transform.forward, facing);
            if (Mathf.Abs(angle) <= angularDeadZone)
            {
                transform.LookAt(transform.position + facing);
            }
            else
            {
                transform.rotation = Quaternion.Lerp(transform.rotation,
                                                     Quaternion.LookRotation(facing),
                                                     Time.deltaTime * angularDampeningTime);
            }

        }
    }

    public virtual void MoveToPoint(Vector3 point)
    {
        facingTarget = false;
        agent.SetDestination(point);
    }

    public void FaceTarget()
    {
        facingTarget = true;
    }

    public void MoveToTarget(float interactionRange)
    {
        Vector3 directionVector = (transform.position - target.position).normalized;
        Vector3 destination = directionVector * (interactionRange + target.GetComponent<TargetRadius>().radius+agent.radius) + target.position; //Target Radius is a place holder class
        agent.SetDestination(destination); 
    }

    public bool IsInInteractionRange(float interactionRange)
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance < target.GetComponent<TargetRadius>().radius + interactionRange + agent.radius) //Target Radius is a place holder class
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        if (agent != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, agent.desiredVelocity + transform.position);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, targetDirection + transform.position);
        }
    }
}
