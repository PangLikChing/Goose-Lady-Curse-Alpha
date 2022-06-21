using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This scriptable object stores the data of an equipment in the feet slot
/// </summary>

[CreateAssetMenu(menuName = "Item/Equipment/Feet")]
public class FeetEquipment : Equipment
{
    // When this scriptable object is created
    void Awake()
    {
        // Set the slot number to 4 to identify that this is an equipment for the feet slot
        slotNumber = 4;
    }
}
