using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventorySlotIntEventListener : MonoBehaviour
{
    [Tooltip("The event channel scritpable object")]
    public InventorySlotIntEventChannel channel;
    [Tooltip("Callback to respond to the unity event")]
    public UnityEvent<InventorySlot, int> response;

    private void OnEnable()
    {
        channel.RegisterListener(this);
    }

    private void OnDisable()
    {
        channel.UnregisterListener(this);
    }

    public void OnEventRaised(InventorySlot inventorySlot, int integer)
    {
        response.Invoke(inventorySlot, integer);
    }
}
