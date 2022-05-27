using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
/// <summary>
/// The state machine is where the actual control takes place
/// </summary>
public class PlayerFSM: FSM
{
    public InputReader inputReader;
    public GameObject avatar;
    public readonly int MovementStateName = Animator.StringToHash("Movement");
    public readonly int IdleStateName = Animator.StringToHash("Idle");
    public readonly int PickupStateName = Animator.StringToHash("Pickup");
    public readonly int AttackStateName = Animator.StringToHash("Attack");

    [HideInInspector]
    public CinemachineStateDrivenCamera playerCameraController;
    [HideInInspector]
    public AvatarLocomotion motion;
    [HideInInspector]
    public AvatarActions actions;
    [HideInInspector]
    public Vector3 destinationPoint;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        inputReader.EnableGameplayInput();
        playerCameraController = GetComponent<CinemachineStateDrivenCamera>();
        motion = avatar.GetComponent<AvatarLocomotion>();
        actions = avatar.GetComponent<AvatarActions>();
        inputReader.MovementEvent += MovementState;
        inputReader.PickupEvent += PickupState;
        inputReader.AttackEvent += AttackState;
    }

    private void OnDisable()
    {
        inputReader.MovementEvent -= MovementState;
        inputReader.PickupEvent -= PickupState;
        inputReader.AttackEvent -= AttackState;
    }

    public void MovementState(Vector3 point)
    {
        destinationPoint = point;
        SetState(MovementStateName);
    }

    public void PickupState(Transform item)
    {
        motion.target = item;
        SetState(PickupStateName);
    }

    public void AttackState(Transform enemy)
    {
        motion.target = enemy;
        SetState(AttackStateName);
    }
}
