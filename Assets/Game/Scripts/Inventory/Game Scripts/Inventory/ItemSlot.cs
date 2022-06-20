using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class stores the data of a held item in the inventory
/// </summary>

public class ItemSlot
{
    // slottedItem is the item in the slot
    public Item slottedItem = null;

    // stackNumber is the number of items that is currently in the stack
    public int stackNumber = 0;
}
