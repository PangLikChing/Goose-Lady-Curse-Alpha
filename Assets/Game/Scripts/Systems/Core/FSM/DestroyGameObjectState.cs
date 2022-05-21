using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObjectState : FSMBaseState<FSM>
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(owner);
    }
}
