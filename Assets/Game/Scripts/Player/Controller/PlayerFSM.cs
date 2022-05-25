using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerFSM: FSM
{
    public InputHandler inputHandler;

    public readonly int RoamingStateName = Animator.StringToHash("Roaming");
    [HideInInspector]
    public CinemachineStateDrivenCamera playerCameraController;
    [HideInInspector]
    public GameObject avatar;
    protected override void Awake()
    {
        avatar = GameObject.FindGameObjectWithTag("Player");
        playerCameraController = GetComponent<CinemachineStateDrivenCamera>();
        base.Awake();
    }
}
