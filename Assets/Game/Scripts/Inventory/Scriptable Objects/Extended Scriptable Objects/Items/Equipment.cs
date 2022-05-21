using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This scriptable object stores the data of an equipment
/// </summary>

public class Equipment : Item
{
    // When this scriptable object is created
    void Awake()
    {
        // Set the maximum stack number to 1
        maxStackNumber = 1;
    }

    // If the value changed for the scriptable object
    void OnValidate()
    {
        // If max stack number is not 1
        if (maxStackNumber != 1)
        {
            // Set the maximum stack number to 1
            maxStackNumber = 1;
        }
    }

    public override void Add(ItemSlot heldItem, int stackNumber)
    {
        // Throw a debug message
        Debug.Log("Equipment Add");

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
        Debug.Log("Equipment Consume");

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
}
