using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This state handles behaviors after the player issue pickup command
/// </summary>
public class PlayerPickupState : PlayerBaseState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SceneLoader.Instance.OnSceneUnloadedEvent += UnRegisterCallbacks;
        if (fsm.actions.IsInPickupRange())
        {
            PickupItem();
        }
        else
        {
            fsm.motion.MoveToTarget(fsm.actions.pickUpRange);
        }
        //fsm.inputReader.EnableGameplayInput();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (fsm.actions.IsInPickupRange())
        {
            PickupItem();
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        fsm.actions.CancelPickup();
        UnRegisterCallbacks();
    }
    
    public void UnRegisterCallbacks()
    {
        SceneLoader.Instance.OnSceneUnloadedEvent -= UnRegisterCallbacks;
    }
    public void PickupItem()
    {
        fsm.actions.PickUp(fsm.motion.target);
        IdleState();
    }
    public void IdleState()
    {
        fsm.ChangeState(fsm.IdleStateName);
    }
}
