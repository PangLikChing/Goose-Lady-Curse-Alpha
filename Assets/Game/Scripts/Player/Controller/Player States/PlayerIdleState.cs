using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The default avatar state
/// </summary>
public class PlayerIdleState : PlayerBaseState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SceneLoader.Instance.OnSceneUnloadedEvent += UnRegisterCallbacks;
        //fsm.inputReader.EnableGameplayInput();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        UnRegisterCallbacks();
    }

    public void UnRegisterCallbacks()
    {
        SceneLoader.Instance.OnSceneUnloadedEvent -= UnRegisterCallbacks;
    }
}
