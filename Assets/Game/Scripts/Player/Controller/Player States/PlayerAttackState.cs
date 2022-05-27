using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SceneLoader.Instance.OnSceneUnloadedEvent += UnRegisterCallbacks;
        fsm.inputReader.EnableGameplayInput();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (fsm.actions.IsInAttackRange())
        {
            fsm.motion.FaceTarget();
            fsm.actions.Attack(fsm.motion.target);
        }
        else
        {
            fsm.actions.CancelAttack();
            fsm.motion.MoveToTarget(fsm.actions.attackRange);
        }
        
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        fsm.actions.CancelAttack();
        UnRegisterCallbacks();
    }

    public void UnRegisterCallbacks()
    {
        SceneLoader.Instance.OnSceneUnloadedEvent -= UnRegisterCallbacks;
    }

    public void IdleState()
    {
        fsm.ChangeState(fsm.IdleStateName);
    }
}
