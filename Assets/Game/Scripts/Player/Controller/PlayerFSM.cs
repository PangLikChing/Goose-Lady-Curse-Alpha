using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM: FSM
{
    public GameObject avatar;
    [HideInInspector]
    public readonly int RoamingStateName = Animator.StringToHash("Roaming");

    protected override void Awake()
    {
        base.Awake();
    }
}
