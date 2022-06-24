using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class StringEventListener : MonoBehaviour
{
    [Tooltip("The event channel scritpable object")]
    public StringEventChannel channel;
    [Tooltip("Callback to respond to the unity event")]
    public UnityEvent<string> response;

    private void OnEnable()
    {
        channel.RegisterListener(this);
    }

    private void OnDisable()
    {
        channel.UnregisterListener(this);
    }

    public void OnEventRaised(string str)
    {
        response.Invoke(str);
    }
}
