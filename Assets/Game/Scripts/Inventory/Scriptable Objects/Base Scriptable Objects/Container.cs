using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This scriptable object stores the data of a container
/// </summary>

[CreateAssetMenu(menuName = "Inventory/Container")]
public class Container : Equipment
{
    // volume is the number of items that the container can hold;
    [SerializeField] protected int volume = 1;

    // heldItems is the items that the container is currently holding
    public ItemSlot[] heldItems = new ItemSlot[1];

    // If a value is changed
    private void OnValidate()
    {
        // If the volume of the container is changed
        if (volume != heldItems.Length)
        {
            // Get the new size of the container
            int newSize = volume;

            // Initialize a temp ItemSlot array
            ItemSlot[] tempItemSlotArray = new ItemSlot[newSize];

            // For the length of the temp ItemSlot array
            for (int i = 0; i < tempItemSlotArray.Length; i++)
            {
                try
                {
                    // Copy the item from heldItems to temp ItemSlot Array
                    tempItemSlotArray[i] = heldItems[i];
                }
                catch
                {
                    // Stop the loop
                    break;
                }
            }

            // Change heldItems to temp ItemSlot Array
            heldItems = tempItemSlotArray;
        }
    }

    // Debug
    public void DisplayItems()
    {
        //// For every element in heldItems
        //for (int i = 0; i < heldItems.Length; i++)
        //{
        //    // If an item exists in heldItems[i]
        //    if (heldItems[i] != null)
        //    {
        //        // Throw a debug message with that item's name
        //        Debug.Log($"{heldItems[i].slottedItem.name}\t");
        //    }
        //    // Else
        //    else
        //    {
        //        // Throw a debug message with null
        //        Debug.Log("Null\t");
        //    }
        //}
    }
}
