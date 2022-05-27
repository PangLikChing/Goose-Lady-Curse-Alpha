using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// The receiver end of a void event channel, attach it to the reciever game object 
/// </summary>
public class VoidEventListener : MonoBehaviour
{
    [Tooltip("The event channel scritpable object")]
    public VoidEventChannel channel;
    [Tooltip("Callback to respond to the unity event")]
    public UnityEvent response;

    private void OnEnable()
    {
        channel.RegisterListener(this);
    }

    private void OnDisable()
    {
        channel.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        response.Invoke();
    }
}
