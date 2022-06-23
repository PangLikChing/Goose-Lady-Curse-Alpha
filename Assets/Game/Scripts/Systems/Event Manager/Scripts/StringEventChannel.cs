using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "StringEventChannel", menuName = "Event/String Event Channel")]
public class StringEventChannel : ScriptableObject
{
    private List<StringEventListener> listeners = new List<StringEventListener>();
    public void Raise(string str)
    {
        Debug.Log(listeners.Count);
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(str);
        }
    }

    public void RegisterListener(StringEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(StringEventListener listener)
    {
        listeners.Remove(listener);
    }
}
