using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This scriptable object stores the data of an equipment in the hand slot
/// </summary>

[CreateAssetMenu(menuName = "Item/Equipment/Hand")]
public class HandEquipment : Equipment
{
    // When this scriptable object is created
    void Awake()
    {
        // Set the slot number to 3 to identify that this is an equipment for the hand slot
        slotNumber = 3;
    }
}
