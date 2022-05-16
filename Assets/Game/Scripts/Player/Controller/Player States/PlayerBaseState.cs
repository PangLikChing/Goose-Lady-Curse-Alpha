using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : FSMBaseState<PlayerFSM>
{
    protected PlayerController controller;
    protected AvatarLocomotion motion;
    public override void Init(GameObject _owner, FSM _fsm)
    {
        base.Init(_owner, _fsm);
        controller = PlayerController.Instance;
        motion = fsm.avatar.GetComponent<AvatarLocomotion>();
    }
}
