using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
public class Structure : MonoBehaviour
{
    public UnityEvent<bool> InInteractionRange;
    public virtual void Interact()
    {
        Debug.Log($"Interacting with{gameObject.name}");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<AvatarActions>(out AvatarActions actions))
        {
            actions.interactionTarget = this;
            InInteractionRange.Invoke(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<AvatarActions>(out AvatarActions actions))
        {
            actions.interactionTarget = null;
            InInteractionRange.Invoke(false);
        }
    }
}
