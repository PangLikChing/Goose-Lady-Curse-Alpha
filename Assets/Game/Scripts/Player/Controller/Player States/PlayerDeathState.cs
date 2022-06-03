using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : PlayerBaseState
{
    public float deathCountDown = 5;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        deathCountDown = 5;
        fsm.actions.Die();
        fsm.inputReader.DisableAllInput();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (deathCountDown > 0)
        {
            deathCountDown -= Time.deltaTime;
        }
        else
        {
            fsm.ChangeState(fsm.SpawnStateName);
        }
    }
}
