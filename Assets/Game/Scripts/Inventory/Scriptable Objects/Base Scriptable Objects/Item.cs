using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This scriptable object stores the data of an item stack
/// </summary>

[CreateAssetMenu(menuName = "Item/Item")]
public class Item : ScriptableObject
{
    // itemID is the ID of that item
    public int itemID = -1;

    // itemDisplayName is the display name of that item on the screen
    public string itemDisplayName = "";

    // itemIcon is the 2D item icon appears in the inventory or amour slots
    public Sprite itemIcon = null;

    // item3DModelPrefeb is the 3D Prefeb asset that will show up on the screen outside of the inventory
    public Transform item3DModelPrefeb = null;

    // maxStackNumber is the maximum number of items that a stack can hold
    public int maxStackNumber = 99;

    // Method to add stack number
    public virtual void Add(ItemSlot heldItem, int stackNumber)
    {
        // Throw a debug message
        Debug.Log("Item Add");

        // If the stack number after adding is less than or equal to the max stack number of that item
        if (heldItem.stackNumber + stackNumber <= heldItem.slottedItem.maxStackNumber)
        {
            // Increase the number of item in the stack by stackNumber
            heldItem.stackNumber += stackNumber;
        }

        // Throw a debug message
        Debug.Log($"{this.name}'s current stack number: {heldItem.stackNumber}");
    }

    public virtual void Consume(ItemSlot heldItem, int stackNumber)
    {
        // Throw a debug message
        Debug.Log("Item Consume");

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

    public virtual void Use(ItemSlot itemSlot)
    {
        // Throw a debug message
        Debug.Log("Item Use, do nothing");
    }
}
