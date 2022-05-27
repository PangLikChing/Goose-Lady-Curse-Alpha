using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// The receiver end of a scriptable object event channel, attach it to the reciever game object 
/// </summary>
public class ScriptableObjectEventListener : MonoBehaviour
{
    [Tooltip("The event channel scritpable object")]
    public ScriptableObjectEventChannel channel;
    [Tooltip("Callback to respond to the unity event")]
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
