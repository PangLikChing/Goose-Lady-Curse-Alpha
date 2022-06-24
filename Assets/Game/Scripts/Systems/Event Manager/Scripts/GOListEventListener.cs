using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GOListEventListener : MonoBehaviour
{
    [Tooltip("The event channel scritpable object")]
    public GOListEventChannel channel;
    [Tooltip("Callback to respond to the unity event")]
    public UnityEvent<List<GameObject>> response;

    private void OnEnable()
    {
        channel.RegisterListener(this);
    }

    private void OnDisable()
    {
        channel.UnregisterListener(this);
    }

    public void OnEventRaised(List<GameObject> goList)
    {
        response.Invoke(goList);
    }
}
