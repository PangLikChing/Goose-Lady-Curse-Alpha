using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GOListEventChannel", menuName = "Event/GO List Event Channel")]
public class GOListEventChannel : ScriptableObject
{
    private List<GOListEventListener> listeners = new List<GOListEventListener>();
    public void Raise(List<GameObject> goList)
    {
        Debug.Log(listeners.Count);
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(goList);
        }
    }

    public void RegisterListener(GOListEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(GOListEventListener listener)
    {
        listeners.Remove(listener);
    }
}
