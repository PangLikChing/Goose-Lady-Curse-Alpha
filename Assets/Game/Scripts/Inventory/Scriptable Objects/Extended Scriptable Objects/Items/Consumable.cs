using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This scriptable object stores the data of a consumable
/// </summary>

[CreateAssetMenu(menuName = "Item/Consumable/Consumable")]
public class Consumable : Item
{
    // A list of item effects for that consumable
    public List<ItemEffect> itemEffect = new List<ItemEffect>();

    // heldItem is the item in the inventory that the player used
    // If the player used the item with a hotkey, we use the first stack found in the inventory.
    // If the player used the item with right-click use, we use the stack the player chose.
    [HideInInspector] public ItemSlot heldItem = null;

    public override void Add(ItemSlot heldItem, int stackNumber)
    {
        // Throw a debug message
        Debug.Log("Consumable Add");

        // If the stack number after adding is less than or equal to the max stack number of that item
        if (heldItem.stackNumber + stackNumber <= heldItem.slottedItem.maxStackNumber)
        {
            // Increase the number of item in the stack by stackNumber
            heldItem.stackNumber += stackNumber;
        }

        // Throw a debug message
        Debug.Log($"{this.name}'s current stack number: {heldItem.stackNumber}");
    }

    public override void Consume(ItemSlot heldItem, int stackNumber)
    {
        // Throw a debug message
        Debug.Log("Consumable Consume");

        // Decrease the number of item in the stack by stackNumber
        heldItem.stackNumber -= stackNumber;

        // Should delete the item if stackNumber is 0 or less than 0
        if (heldItem.stackNumber <= 0)
        {
            // Dereference the slottedItem
            heldItem.slottedItem = null;
        }

        // Throw a debug message
        Debug.Log($"{this.name}'s current stack number: {heldItem.stackNumber}");
    }

    public void Use()
    {
        // For every item effects in the itemEffect list
        for (int i = 0; i < itemEffect.Count; i++)
        {
            // Conduct the effect
            itemEffect[i].UseItem();
        }
    }
}
