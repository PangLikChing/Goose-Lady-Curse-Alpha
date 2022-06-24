using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EquipmentSlotEventListener : MonoBehaviour
{
    [Tooltip("The event channel scritpable object")]
    public EquipmentSlotEventChannel channel;
    [Tooltip("Callback to respond to the unity event")]
    public UnityEvent<EquipmentSlot> response;

    private void OnEnable()
    {
        channel.RegisterListener(this);
    }

    private void OnDisable()
    {
        channel.UnregisterListener(this);
    }

    public void OnEventRaised(EquipmentSlot equipmentSlot)
    {
        response.Invoke(equipmentSlot);
    }
}
