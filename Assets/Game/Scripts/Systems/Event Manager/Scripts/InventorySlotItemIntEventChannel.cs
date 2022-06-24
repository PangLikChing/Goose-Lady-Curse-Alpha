using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventorySlotItemIntEventChannel", menuName = "Event/InventorySlot Item Int Event Channel")]
public class InventorySlotItemIntEventChannel : ScriptableObject
{
    private List<InventorySlotItemIntEventListener> listeners = new List<InventorySlotItemIntEventListener>();
    public void Raise(InventorySlot inventorySlot, Item item, int integer)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(inventorySlot, item, integer);
        }
    }

    public void RegisterListener(InventorySlotItemIntEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(InventorySlotItemIntEventListener listener)
    {
        listeners.Remove(listener);
    }
}
