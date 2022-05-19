using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class AvatarLocomotion : MonoBehaviour
{
    public Transform target;
    public float speedDampeningTime = 3;
    public float speedDeadZone = 0.001f;
    public float angularDampeningTime = 5.0f;
    public float angularDeadZone = 10.0f;
    public float stoppingDistance = 0.2f;
    public bool useRootMotion;


    private readonly int SpeedParameter = Animator.StringToHash("speed");
    private AnimationListener animationListener;
    private NavMeshAgent agent;
    private Animator avatarAnimator;
    private float targetSpeed;
    private float currentSpeed;
    private bool hasAnimationListner;
    private bool hasAnimator;



    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        hasAnimationListner = TryGetComponent<AnimationListener>(out animationListener);
        hasAnimator = TryGetComponent<Animator>(out avatarAnimator);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (hasAnimationListner)
        {
            animationListener.OnAnimatorMoveEvent += OnAnimatorMove;
        }
    }

    private void OnAnimatorMove()
    {
        if (useRootMotion)
        {
            agent.velocity = avatarAnimator.deltaPosition / Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hasAnimator)
        {
            if (useRootMotion)
            {
                if (agent.remainingDistance < agent.radius)
                {
                    targetSpeed = 0;
                }
                else
                {
                    targetSpeed = agent.desiredVelocity.magnitude;
                }

                if (Mathf.Abs(currentSpeed - targetSpeed) > speedDeadZone)
                {
                    currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, speedDampeningTime * Time.deltaTime);
                    //currentSpeed = Vector3.Lerp(agent.velocity,agent.desiredVelocity, speedDampeningTime * Time.deltaTime).magnitude;
                }
                else
                {
                    currentSpeed = targetSpeed;
                }
                avatarAnimator.SetFloat(SpeedParameter, currentSpeed);
            }
            else 
            {
                avatarAnimator.SetFloat(SpeedParameter, agent.velocity.magnitude);
            }

            if (agent.remainingDistance > agent.radius)
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
        //if (target != null)
        //{
        //    MoveToPoint(target.position);
        //    FaceTarget();
        //}
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }
}
