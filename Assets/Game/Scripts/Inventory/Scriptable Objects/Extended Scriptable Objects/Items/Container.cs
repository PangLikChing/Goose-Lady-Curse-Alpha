using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This scriptable object stores the data of a container
/// </summary>

[CreateAssetMenu(menuName = "Item/Equipment/Container")]
public class Container : Item
{
    public UnityEvent<ItemSlot> equipBag;

    // volume is the number of items that the container can hold;
    public int volume = 1;

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

    // If the value changed for the scriptable object
    void OnValidate()
    {
        //// If equipment slot is not null
        //if (equipmentSlot != null)
        //{
        //    // Reset equipment slot
        //    equipmentSlot = null;
        //}

        // If max stack number is not 1
        if (maxStackNumber != 1)
        {
            // Set the maximum stack number to 1
            maxStackNumber = 1;
        }

        //// If the user expend the modifiers array
        //if (modifiers.Length != 0)
        //{
        //    // Reset modifiers
        //    modifiers = new Modifier[0];
        //}
    }

    // Equipping the bag if a bag slot is available
    public override void Use(ItemSlot itemSlot)
    {
        equipBag.Invoke(itemSlot);
    }
}
