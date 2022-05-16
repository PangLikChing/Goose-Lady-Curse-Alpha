using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerRoamingState : PlayerBaseState
{

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller.MoveCmd.AddListener(MoveAvatar);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller.MoveCmd.RemoveListener(MoveAvatar);
    }

    public void MoveAvatar(Vector3 point)
    {
        motion.MoveToPoint(point);
    }

}
