using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A channel that allows cross scene event that pass scriptable object parameters
/// </summary>
[CreateAssetMenu(fileName = "VoidEventChannel", menuName = "Event/Scriptable Object Event Channel")]
public class ScriptableObjectEventChannel : ScriptableObject
{
    private List<ScriptableObjectEventListener> listeners = new List<ScriptableObjectEventListener>();
    public void Raise(ScriptableObject scriptableObject)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(scriptableObject);
        }
    }

    public void RegisterListener(ScriptableObjectEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(ScriptableObjectEventListener listener)
    {
        listeners.Remove(listener);
    }
}
