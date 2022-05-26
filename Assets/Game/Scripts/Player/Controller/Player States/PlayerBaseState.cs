using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : FSMBaseState<PlayerFSM>
{
    public override void Init(GameObject _owner, FSM _fsm)
    {
        base.Init(_owner, _fsm);
    }
}
