using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM: FSM
{ 
    [HideInInspector]
    public LayerMask movementLayerMask;
    [HideInInspector]
    public Camera mainCam;
    [HideInInspector]
    public readonly int RoamingStateName = Animator.StringToHash("Roaming");

    protected override void Awake()
    {
        base.Awake();
        mainCam = Camera.main;
        movementLayerMask = LayerMask.GetMask("Terrain");
    }
}
