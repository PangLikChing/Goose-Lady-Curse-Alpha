using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// PlayerInventory is the bags that the player is carrying
/// </summary>

public class PlayerInverntory : MonoBehaviour
{
    [SerializeField] Inventory myInventory;

    [SerializeField] Transform inventoryBackground;

    //test
    [SerializeField] Test test;
    //test

    public UnityEvent Open;

    // Method to display player's inventory
    public void OpenInventory()
    {
        // Throw a debug message
        Debug.Log($"Opening {this.name} 's inventory.");

        // Cache the bags
        List<Container> bags = myInventory.bagSlots;

        //// Assign inventory slots
        // For every bag
        for (int i = 0; i < bags.Count; i++)
        {
            // For eveny item in the bag
            for (int j = 0; j < bags[i].heldItems.Length; j++)
            {
                // Assign the ItemSlot Scriptable Object
                bags[i].heldItems[j] = test.itemSlots[j];
            }
        }

        // Read Data
        // For every bag
        for (int i = 0; i < bags.Count; i++)
        {
            // For eveny item in the bag
            for (int j = 0; j < bags[i].heldItems.Length; j++)
            {
                // Cache the current inventory slot
                Transform currentSlot = inventoryBackground.GetChild(j).GetChild(0);

                // If there is an item in that slot
                if (bags[i].heldItems[j].slottedItem != null)
                {
                    // Change the sprite of that itemslot into the one of the item
                    currentSlot.GetComponent<Image>().sprite = bags[i].heldItems[j].slottedItem.itemIcon;

                    // If the stack number of the item in that inventory slot is larger than or equals to 2
                    if (bags[i].heldItems[j].stackNumber >= 2)
                    {
                        // Change the stack number text to the stackNumber of the item in the inventory slot
                        currentSlot.GetChild(0).GetComponent<TMP_Text>().text = bags[i].heldItems[j].stackNumber.ToString();
                    }
                    // If the stack number of the item in that inventory slot is less than 2
                    else
                    {
                        // Disable the stack number text
                        currentSlot.GetChild(0).gameObject.SetActive(false);
                    }
                }
                // Else
                else
                {
                    // Remove the sprite
                    currentSlot.GetComponent<Image>().sprite = null;

                    // Disable the stack number text
                    currentSlot.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
    }
}
