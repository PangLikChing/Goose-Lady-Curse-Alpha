using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemIntEventChannel", menuName = "Event/ItemSlot Event Channel")]
public class ItemSlotEventChannel : ScriptableObject
{
    private List<ItemSlotEventListener> listeners = new List<ItemSlotEventListener>();
    public void Raise(ItemSlot itemSlot)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(itemSlot);
        }
    }

    public void RegisterListener(ItemSlotEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(ItemSlotEventListener listener)
    {
        listeners.Remove(listener);
    }
}
