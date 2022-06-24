using UnityEngine;
using Cinemachine;

/// <summary>
/// The state machine is where the actual control takes place
/// Each state corresponds to a player command which are
///     1) Move
///     2) Pickup
///     3) Attack
/// </summary>
public class PlayerFSM: FSM
{
    [Tooltip("Reference to input reader")]
    public InputReader inputReader;
    [Tooltip("Reference to the avatar player will be controlling")]
    public GameObject avatar;

    public readonly int MovementStateName = Animator.StringToHash("Movement");
    public readonly int IdleStateName = Animator.StringToHash("Idle");
    public readonly int PickupStateName = Animator.StringToHash("Pickup");
    public readonly int AttackStateName = Animator.StringToHash("Attack");
    public readonly int DeathStateName = Animator.StringToHash("Death");
    public readonly int SpawnStateName = Animator.StringToHash("Spawn");

    [HideInInspector]
    public CinemachineStateDrivenCamera playerCameraController;
    [HideInInspector]
    public AvatarLocomotion motion;
    [HideInInspector]
    public AvatarActions actions;
    [HideInInspector]
    public bool isDead;


    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        //inputReader.EnableGameplayInput();
        playerCameraController = GetComponent<CinemachineStateDrivenCamera>();
        motion = avatar.GetComponent<AvatarLocomotion>();
        actions = avatar.GetComponent<AvatarActions>();
        inputReader.MovementEvent += MovementState;
        inputReader.PickupEvent += PickupState;
        inputReader.AttackEvent += AttackState;
        inputReader.InteractEvent += actions.Interact;
    }

    private void OnDisable()
    {
        inputReader.MovementEvent -= MovementState;
        inputReader.PickupEvent -= PickupState;
        inputReader.AttackEvent -= AttackState;
        inputReader.InteractEvent -= actions.Interact;
    }

    public void ResetState()
    {
        SetState(IdleStateName);
        motion.ResetState();
        actions.ResetState();
    }

    public void MovementState(Vector3 point)
    {
        motion.destinationPoint = point;
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

    public void DeathState()
    {
        isDead = true;
        motion.Halt();
        SetState(DeathStateName);
    }

    public void SpawnState()
    {
        isDead = false;
        SetState(SpawnStateName);
    }
}
