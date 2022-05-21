using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is responsible for managing the bags display
/// </summary>

public class InventoryGrouper : MonoBehaviour
{
    // myInventory is the inventory that this script is responsible for. Should assign somewhere else
    public Inventory myInventory;

    // bagGameObject is the UI prefeb for a bag
    public Transform bagTransform, inventorySlotTransform;

    // If the inventory is opened
    void OnEnable()
    {
        // For every bag slot
        for (int i = 0; i < myInventory.bags.Count; i++)
        {
            // Instantiate a bag UI GameObject
            Transform newBag = Instantiate(bagTransform, transform);

            // If there is a bag in that bag slot
            if (myInventory.bags[i] != null)
            {
                // For every element in the bag
                for (int j = 0; j < myInventory.bags[i].volume; j++)
                {
                    // Instantiate a new inventory slot UI GameObject
                    Instantiate(inventorySlotTransform, newBag);
                }
            }
        }
    }
}
