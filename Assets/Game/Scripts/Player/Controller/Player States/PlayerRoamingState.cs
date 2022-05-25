using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerRoamingState : PlayerBaseState
{

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        fsm.inputHandler.MovementEvent += MoveAvatar;   
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        fsm.inputHandler.MovementEvent -= MoveAvatar;
    }

    public void MoveAvatar(Vector3 destination)
    {
        motion.MoveToPoint(destination);
    }

    
}
