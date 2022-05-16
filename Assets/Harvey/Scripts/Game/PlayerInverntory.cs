using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// PlayerInventory is the bags that the player is carrying
/// </summary>

public class PlayerInverntory : MonoBehaviour
{
    [SerializeField] Inventory myInventory;

    [SerializeField] Transform inventoryBackground;

    public UnityEvent Open;

    // Method to display player's inventory
    public void OpenInventory()
    {
        // Throw a debug message
        Debug.Log($"Opening {this.name} 's inventory.");

        // Cache the bags
        List<Container> bags = myInventory.bagSlots;

        // Read Data
        // For every bag
        for (int i = 0; i < bags.Count; i++)
        {
            // For eveny item in the bag
            for (int j = 0; j < bags[i].heldItems.Length; j++)
            {
                // If there is an item in that slot
                if (bags[i].heldItems[j] != null)
                {
                    // Change the sprite of that itemslot into the one of the item
                    inventoryBackground.GetChild(j).GetChild(0).GetComponent<Image>().sprite = bags[i].heldItems[j].itemIcon;
                }
                // Else
                else
                {
                    // Remove the sprite
                    inventoryBackground.GetChild(j).GetChild(0).GetComponent<Image>().sprite = null;
                }
            }
        }
    }
}
