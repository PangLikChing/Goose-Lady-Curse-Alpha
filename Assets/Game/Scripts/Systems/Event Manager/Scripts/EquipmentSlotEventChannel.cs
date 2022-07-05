using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentSlotEventChannel", menuName = "Event/Equipment Slot Event Channel")]
public class EquipmentSlotEventChannel : ScriptableObject
{
    private List<EquipmentSlotEventListener> listeners = new List<EquipmentSlotEventListener>();
    public void Raise(EquipmentSlot equipmentSlot)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(equipmentSlot);
        }
    }

    public void RegisterListener(EquipmentSlotEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(EquipmentSlotEventListener listener)
    {
        listeners.Remove(listener);
    }
}
