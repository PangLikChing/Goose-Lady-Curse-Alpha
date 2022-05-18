using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class AvatarLocomotion : MonoBehaviour
{
    public Transform target;
    public float angularDampeningTime = 5.0f;
    public float deadZone = 10.0f;

    private readonly int SpeedParameter = Animator.StringToHash("speed");
    private AnimationListener animationListener;
    private NavMeshAgent agent;
    private Animator avatarAnimator;
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
            //animationListener.OnAnimatorMoveEvent += OnAnimatorMove;
        }
        
    }

    //private void OnAnimatorMove()
    //{
    //    agent.velocity = avatarAnimator.deltaPosition / Time.deltaTime;
    //}

    // Update is called once per frame
    void Update()
    {
        if (hasAnimator)
        {
            if (agent.desiredVelocity != Vector3.zero)
            {
                //float speed = Vector3.Project(agent.desiredVelocity, transform.forward).magnitude * agent.speed;
                float speed = agent.desiredVelocity.magnitude;
                avatarAnimator.SetFloat(SpeedParameter, speed);

                float angle = Vector3.Angle(transform.forward, agent.desiredVelocity);
                if (Mathf.Abs(angle) <= deadZone)
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
            else
            {
                avatarAnimator.SetFloat(SpeedParameter, 0.0f);
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
