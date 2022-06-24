using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SteeringAgent : MonoBehaviour
{
	public enum SummingMethod
	{
		WeightedAverage,
		Prioritized,
	};
	public SummingMethod summingMethod = SummingMethod.WeightedAverage;

	public bool UseGravity = true;
	public bool UseRootMotion = true;

	public float mass = 1.0f;
	public float maxSpeed = 1.0f;
	public float maxForce = 10.0f;

	public Vector3 velocity = Vector3.zero;

	private List<SteeringBehaviourBase> steeringBehaviours = new List<SteeringBehaviourBase>();

	public float angularDampeningTime = 5.0f;
	public float deadZone = 10.0f;

	[HideInInspector] public bool reachedGoal = false;

	private Animator animator;
	private CharacterController characterController;

	private void Start()
	{
		animator = GetComponent<Animator>();
		if (animator == null)
        {
			UseRootMotion = false;
        }
		characterController = GetComponent<CharacterController>();

		steeringBehaviours.AddRange(GetComponentsInChildren<SteeringBehaviourBase>());
		foreach(SteeringBehaviourBase behaviour in steeringBehaviours)
		{
			behaviour.steeringAgent = this;
		}
	}

	private void OnAnimatorMove()
	{
		if (Time.deltaTime != 0.0f && UseRootMotion == true)
		{
			Vector3 animationVelocity = animator.deltaPosition / Time.deltaTime;
			characterController.Move((transform.forward * animationVelocity.magnitude) * Time.deltaTime);
			if (UseGravity)
            {
				characterController.Move(Physics.gravity * Time.deltaTime);
            }
			//Vector3 animationVelocity = animator.deltaPosition / Time.deltaTime;
			//transform.position += (transform.forward * animationVelocity.magnitude) * Time.deltaTime;
		}
	}

	private void Update()
	{
		Vector3 steeringForce = calculateSteeringForce();
		//steeringForce.y = 0.0f;

		if (reachedGoal == true)
		{
			velocity = Vector3.zero;
			if (animator != null)
            {
				animator.SetFloat("Speed", 0.0f);
			}
		}
		else
		{
			Vector3 acceleration = steeringForce / mass;
			velocity = velocity + (acceleration * Time.deltaTime);
			velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

			float speed = velocity.magnitude;
			if (animator != null)
            {
				animator.SetFloat("Speed", speed);
			}

			if (!UseRootMotion)
            {
				characterController.Move(velocity * Time.deltaTime);
				if (UseGravity)
                {
					characterController.Move(Physics.gravity * Time.deltaTime);
                }
            }
		}

		if (velocity.magnitude > 0.0f)
		{
			Vector3 tempV = new Vector3(velocity.x, 0.0f, velocity.z);

			float angle = Vector3.Angle(transform.forward, tempV);
			if (Mathf.Abs(angle) <= deadZone)
			{
				transform.LookAt(transform.position + tempV);
			}
			else
			{
				transform.rotation = Quaternion.Slerp(transform.rotation,
													  Quaternion.LookRotation(tempV),
													  Time.deltaTime * angularDampeningTime);
			}
		}
	}

	private Vector3 calculateSteeringForce()
	{
		Vector3 totalForce = Vector3.zero;

		foreach(SteeringBehaviourBase behaviour in steeringBehaviours)
		{
			if (behaviour.enabled)
			{
				switch(summingMethod)
				{
					case SummingMethod.WeightedAverage:
						totalForce = totalForce + (behaviour.CalculateForce() * behaviour.weight);
						totalForce = Vector3.ClampMagnitude(totalForce, maxForce);
						break;

					case SummingMethod.Prioritized:
						break;
				}

			}
		}

		return totalForce;
	}
}
