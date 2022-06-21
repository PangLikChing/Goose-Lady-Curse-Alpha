using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemSlotEventListener : MonoBehaviour
{
    [Tooltip("The event channel scritpable object")]
    public ItemSlotEventChannel channel;
    [Tooltip("Callback to respond to the unity event")]
    public UnityEvent<ItemSlot> response;

    private void OnEnable()
    {
        channel.RegisterListener(this);
    }

    private void OnDisable()
    {
        channel.UnregisterListener(this);
    }

    public void OnEventRaised(ItemSlot itemSlot)
    {
        response.Invoke(itemSlot);
    }
}
