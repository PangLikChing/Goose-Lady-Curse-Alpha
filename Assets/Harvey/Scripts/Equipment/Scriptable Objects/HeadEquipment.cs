using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This scriptable object stores the data of an equipment in the head slot
/// </summary>


[CreateAssetMenu(menuName = "Item/Equipment/Head")]
public class HeadEquipment : Equipment
{
    // When this scriptable object is created
    void Awake()
    {
        // Set the slot number to 1 to identify that this is an equipment for the head slot
        slotNumber = 1;
    }
}
