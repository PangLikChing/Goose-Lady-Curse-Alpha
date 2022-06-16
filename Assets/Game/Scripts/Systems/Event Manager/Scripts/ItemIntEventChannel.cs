using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemIntEventChannel", menuName = "Event/Item Int Event Channel")]
public class ItemIntEventChannel : ScriptableObject
{
    private List<ItemIntEventListener> listeners = new List<ItemIntEventListener>();
    public void Raise(Item scriptableObject, int integer)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(scriptableObject, integer);
        }
    }

    public void RegisterListener(ItemIntEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(ItemIntEventListener listener)
    {
        listeners.Remove(listener);
    }
}
