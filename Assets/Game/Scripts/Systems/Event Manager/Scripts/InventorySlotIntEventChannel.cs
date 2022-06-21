using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IntIntEventChannel", menuName = "Event/InventorySlot Int Event Channel")]
public class InventorySlotIntEventChannel : ScriptableObject
{
    private List<InventorySlotIntEventListener> listeners = new List<InventorySlotIntEventListener>();

    public void Raise(InventorySlot inventorySlot, int integer)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(inventorySlot, integer);
        }
    }

    public void RegisterListener(InventorySlotIntEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(InventorySlotIntEventListener listener)
    {
        listeners.Remove(listener);
    }
}
