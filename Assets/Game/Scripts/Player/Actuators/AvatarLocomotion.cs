using Project.Build.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

/// <summary>
/// This class handles the avatar's movement
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class AvatarLocomotion : MonoBehaviour
{
    [Tooltip("Angle Change Rate")]
    public float angularDampeningTime = 5.0f;
    [Tooltip("Angle Interpolation Threshold")]
    public float angularDeadZone = 10.0f;
    [ReadOnly, Tooltip("Avatar's current target")]
    public Transform target;
    [ReadOnly, Tooltip("Avatar's current destination point")]
    public Vector3 destinationPoint;

    public event UnityAction PathCompleted = delegate { };
#if UNITY_EDITOR
    [ReadOnly, Tooltip("Avatar's current speed")]
    public float agentSpeed;
#endif

    protected NavMeshAgent agent;
    protected Animator avatarAnimator;
    protected bool hasAnimator;
    protected bool facingTarget;
    protected Vector3 targetDirection;


    public void ResetState()
    {
        target = null;
        destinationPoint = transform.position;
        facingTarget = false;

        //agent.ResetPath();
    }

    public void Halt()
    {
        agent.isStopped = true;
        agent.velocity = Vector3.zero;
        agent.ResetPath();
    }

    /// <summary>
    /// initalize references
    /// </summary>
    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        hasAnimator = TryGetComponent<Animator>(out avatarAnimator);
    }

    /// <summary>
    /// The update method
    ///     1) calculates the avatar's rotation
    ///     2) calculates the avatar's target(item or enemy)'s direction
    ///     3) send an event when path is complete
    /// </summary>
    protected virtual void Update()
    {
#if UNITY_EDITOR
        agentSpeed = agent.velocity.magnitude;
#endif

        if (agent.remainingDistance == 0 && agent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            agent.isStopped = true;
            PathCompleted.Invoke();
        }

        if (target != null)
        {
            targetDirection = target.position - transform.position;
            targetDirection.y = 0;
        }

        if (hasAnimator)
        {
            RotationControl(facingTarget ? targetDirection : agent.desiredVelocity);
        }
    }
    /// <summary>
    /// This method controls the avatar's rotation
    /// It will linear interpolate towards the desired direction which is specified by faceing
    /// </summary>
    /// <param name="facing">The desired direction</param>
    protected virtual void RotationControl(Vector3 facing)
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

    /// <summary>
    /// This method is called when the player clicks the ground
    /// </summary>
    /// <param name="point">The point being clicked</param>
    public virtual void MoveToPoint()
    {
        agent.isStopped = false;
        facingTarget = false;
        agent.SetDestination(destinationPoint);
    }

    /// <summary>
    /// Order avatar to track its target instead of facing the direction give by the navmesh agent
    /// </summary>
    public virtual void FaceTarget()
    {
        facingTarget = true;
    }

    /// <summary>
    /// Order the avatar to approach its target(enemy/item), and arrive at an offset location. 
    /// </summary>
    /// <param name="interactionRange">The offset distance</param>
    public virtual void MoveToTarget(float offsetDistance)
    {
        if (target != null)
        {
            Vector3 destination;
            Vector3 directionVector = (transform.position - target.position).normalized;
            if (target.TryGetComponent<Interactable>(out Interactable targetInteractable))
            {
                destination = directionVector * (offsetDistance + targetInteractable.radius + agent.radius) + target.position;
            }
            else
            {
                destination = directionVector * (offsetDistance + agent.radius) + target.position;
                Debug.LogWarning($"Target {target} has no interactable attached");
            }
            agent.isStopped = false;
            facingTarget = false;
            agent.SetDestination(destination);
        }
        else
        {
            Debug.LogError($"Target is null");
        }
    }

    public void Warp(Vector3 point)
    {
        agent.Warp(point);
    }

    /// <summary>
    /// Check if avatar's target is within interaction range.
    /// </summary>
    /// <param name="interactionRange">The interaction range.</param>
    /// <returns>Return true if target is in range, false otherwise.</returns>
    public virtual bool IsInInteractionRange(float interactionRange)
    {
        if (target == null || target.GetComponent<Interactable>() == null)
        {
            return false;
        }
        float distance = Vector3.Distance(transform.position, target.transform.position);
        
        if (distance < target.GetComponent<Interactable>().radius + interactionRange + agent.radius)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Draws the desired velocity of the avatar's navmesh agent 
    /// Draws the targetDirection.
    /// </summary>
    private void OnDrawGizmos()
    {
        if (agent != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, agent.desiredVelocity + transform.position);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, targetDirection + transform.position);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(destinationPoint, 1);
        }
    }
}
