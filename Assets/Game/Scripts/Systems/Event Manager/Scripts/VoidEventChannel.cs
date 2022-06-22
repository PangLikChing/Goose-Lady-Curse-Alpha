using Project.Build.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A channel that allows cross scene event that pass no parameters
/// </summary>
[CreateAssetMenu(fileName = "VoidEventChannel", menuName = "Event/Void Event Channel")]
public class VoidEventChannel : ScriptableObject
{
    private List<VoidEventListener> listeners = new List<VoidEventListener>();
    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(VoidEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(VoidEventListener listener)
    {
        listeners.Remove(listener);
    }
}
