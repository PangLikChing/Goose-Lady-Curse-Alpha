using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerFSM: FSM
{
    public InputReader inputReader;
    public GameObject avatar;
    public readonly int GameplayStateName = Animator.StringToHash("Gameplay");

    [HideInInspector]
    public CinemachineStateDrivenCamera playerCameraController;
    [HideInInspector]
    public AvatarLocomotion motion;
    [HideInInspector]
    public AvatarActions actions;
    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        playerCameraController = GetComponent<CinemachineStateDrivenCamera>();
        motion = avatar.GetComponent<AvatarLocomotion>();
    }
}
