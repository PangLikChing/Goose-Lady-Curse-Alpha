using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventorySlotItemIntEventListener : MonoBehaviour
{
    [Tooltip("The event channel scritpable object")]
    public InventorySlotItemIntEventChannel channel;
    [Tooltip("Callback to respond to the unity event")]
    public UnityEvent<InventorySlot, Item, int> response;

    private void OnEnable()
    {
        channel.RegisterListener(this);
    }

    private void OnDisable()
    {
        channel.UnregisterListener(this);
    }

    public void OnEventRaised(InventorySlot inventorySlot, Item item, int integer)
    {
        response.Invoke(inventorySlot, item, integer);
    }
}
