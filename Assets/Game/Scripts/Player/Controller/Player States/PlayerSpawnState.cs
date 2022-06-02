using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSpawnState : PlayerBaseState
{
    public float spawnCountDown = 5;
    public UnityEvent playerSpawn;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spawnCountDown = 5;
        fsm.actions.Spawn(fsm.spawnPoint);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (spawnCountDown > 0)
        {
            spawnCountDown -= Time.deltaTime;
        }
        else
        {
            fsm.ChangeState(fsm.IdleStateName);
        }
    }
}
