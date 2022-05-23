using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationListener : MonoBehaviour, IAnimationCompleted
{
    #region Animator Move
    public System.Action OnAnimatorMoveEvent;
    private void OnAnimatorMove()
    {
        if (OnAnimatorMoveEvent != null)
        {
            OnAnimatorMoveEvent();
        }
    }
    #endregion

    #region Animation Completed

    private Dictionary<int, System.Action<int>> animationCompletedEvents = new Dictionary<int, System.Action<int>>();

    public void AddAnimationCompletedListener(int animationName, System.Action<int> callback)
    {
        System.Action<int> action;
        if (animationCompletedEvents.TryGetValue(animationName, out action))
        {
            action += callback;
        }
        else
        {
            animationCompletedEvents.Add(animationName, callback);
        }
    }

    public void RemoveAnimationCompletedListener(int animationName, System.Action<int> callback)
    {
        System.Action<int> action;
        if (animationCompletedEvents.TryGetValue(animationName, out action))
        {
            action -= callback;
        }
    }

    public void AnimationCompleted(int shortHashName)
    {
        System.Action<int> action;
        if (animationCompletedEvents.TryGetValue(shortHashName, out action))
        {
            action(shortHashName);
        }
    }

    #endregion
}
