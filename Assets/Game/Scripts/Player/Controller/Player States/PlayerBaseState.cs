using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : FSMBaseState<PlayerFSM>
{
    protected PlayerController controller;
    protected AvatarLocomotion motion;
    protected AvatarActions actions;
    public override void Init(GameObject _owner, FSM _fsm)
    {
        base.Init(_owner, _fsm);
        controller = PlayerController.Instance;
        motion = controller.avatar.GetComponent<AvatarLocomotion>();
    }
}
