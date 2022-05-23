using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerFSM: FSM
{ 
    [HideInInspector]
    public LayerMask movementLayerMask;
    [HideInInspector]
    public Camera mainCam;
    [HideInInspector]
    public readonly int RoamingStateName = Animator.StringToHash("Roaming");
    [HideInInspector]
    public CinemachineStateDrivenCamera playerCameraController;
    protected override void Awake()
    {
        mainCam = Camera.main;
        movementLayerMask = LayerMask.GetMask("Terrain");
        playerCameraController = GetComponent<CinemachineStateDrivenCamera>();
        base.Awake();
    }
}
