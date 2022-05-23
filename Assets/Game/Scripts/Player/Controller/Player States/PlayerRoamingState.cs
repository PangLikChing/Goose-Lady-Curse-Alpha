using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRoamingState : PlayerBaseState
{
    private Ray ray;
    private RaycastHit hit;

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

    public void MoveAvatar()
    {
        ray = fsm.mainCam.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out hit, 500f, fsm.movementLayerMask))
        {
            motion.MoveToPoint(hit.point);
        }
    }

    
}
