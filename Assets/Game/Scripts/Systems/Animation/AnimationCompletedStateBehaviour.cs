using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCompletedStateBehaviour : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        IAnimationCompleted callback = animator.gameObject.GetComponent(typeof(IAnimationCompleted)) as IAnimationCompleted;
        if (callback != null)
        {
            callback.AnimationCompleted(stateInfo.shortNameHash);
        }
    }
}
