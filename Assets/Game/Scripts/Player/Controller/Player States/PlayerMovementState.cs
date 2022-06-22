using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
/// <summary>
/// Handles avatar move command
/// </summary>
public class PlayerMovementState : PlayerBaseState
{

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SceneLoader.Instance.OnSceneUnloadedEvent += UnRegisterCallbacks;
        fsm.motion.MoveToPoint();
        fsm.motion.PathCompleted += IdleState;
        //fsm.inputReader.EnableGameplayInput();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        UnRegisterCallbacks();
    }

    public void UnRegisterCallbacks()
    {
        fsm.motion.PathCompleted -= IdleState;
        SceneLoader.Instance.OnSceneUnloadedEvent -= UnRegisterCallbacks;
    }

    public void IdleState()
    {
        fsm.ChangeState(fsm.IdleStateName);
    }
}
