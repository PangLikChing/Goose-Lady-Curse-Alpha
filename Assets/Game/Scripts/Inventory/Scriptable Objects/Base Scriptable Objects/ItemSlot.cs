using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This scriptable object stores the data of a held item in the inventory
/// </summary>

[CreateAssetMenu(menuName = "Inventory/Item Slot")]
public class ItemSlot : ScriptableObject
{
    // slottedItem is the item in the slot
    public Item slottedItem = null;

    // stackNumber is the number of items that is currently in the stack
    public int stackNumber = -1;
}
