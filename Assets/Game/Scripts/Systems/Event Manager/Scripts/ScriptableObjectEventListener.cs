using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScriptableObjectEventListener : MonoBehaviour
{
    public ScriptableObjectEventChannel channel;
    public UnityEvent<ScriptableObject> response;

    private void OnEnable()
    {
        channel.RegisterListener(this);
    }

    private void OnDisable()
    {
        channel.UnregisterListener(this);
    }

    public void OnEventRaised(ScriptableObject scriptableObject)
    {
        response.Invoke(scriptableObject);
    }
}
