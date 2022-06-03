using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSpawnState : PlayerBaseState
{
    public UnityEvent playerSpawning;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        fsm.actions.Spawn();
        playerSpawning.Invoke();
        fsm.inputReader.DisableAllInput();
    }
}
