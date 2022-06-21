using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This scriptable object stores the data of an equipment in the chest slot
/// </summary>


[CreateAssetMenu(menuName = "Item/Equipment/Chest")]
public class ChestEquipment : Equipment
{
    // When this scriptable object is created
    void Awake()
    {
        // Set the slot number to 2 to identify that this is an equipment for the chest slot
        slotNumber = 2;
    }
}
