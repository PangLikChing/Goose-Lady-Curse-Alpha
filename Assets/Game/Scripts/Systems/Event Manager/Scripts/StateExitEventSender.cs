using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateExitEventSender : StateMachineBehaviour
{
    public UnityEvent StateExit;

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StateExit.Invoke();
    }
}
