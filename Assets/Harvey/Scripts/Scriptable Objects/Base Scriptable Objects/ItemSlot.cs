using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This scriptable object stores the data of an item slot
/// </summary>

[CreateAssetMenu(menuName = "Scriptable Objects/Item Slot")]
public class ItemSlot : ScriptableObject
{
    // slottedItem is the item in the slot
    public Item slottedItem = null;

    // stackNumber is the number of items that is currently in the stack
    public int stackNumber = -1;
}
