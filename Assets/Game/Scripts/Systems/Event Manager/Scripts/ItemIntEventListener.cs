using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class ItemIntEventListener : MonoBehaviour
{
    [Tooltip("The event channel scritpable object")]
    public ItemIntEventChannel channel;
    [Tooltip("Callback to respond to the unity event")]
    public UnityEvent<Item, int> response;

    private void OnEnable()
    {
        channel.RegisterListener(this);
    }

    private void OnDisable()
    {
        channel.UnregisterListener(this);
    }

    public void OnEventRaised(Item scriptableObject, int integer)
    {
        response.Invoke(scriptableObject, integer);
    }
}
