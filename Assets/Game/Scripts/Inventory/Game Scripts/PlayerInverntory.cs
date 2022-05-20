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

    // test should hold a reference to all the item slots, aka a game manager
    //test
    [SerializeField] Test test;
    //test

    public UnityEvent Open;

    public void AddItem(Item item, int stackNumber)
    {
        // Throw a debug message
        Debug.Log($"Adding {item.name} to {this.name}'s inventory.");

        // Cache the bags
        List<Container> bags = myInventory.bagSlots;

        // Initialize a temp item slot
        ItemSlot targetItemSlot = null;

        // Search for slot
        // For every bag
        for (int i = 0; i < bags.Count; i++)
        {
            // If I have found an item slot with the same item as the item that is going to be added
            if (targetItemSlot != null)
            {
                // Stop the search
                break;
            }

            // For eveny item in the bag
            for (int j = 0; j < bags[i].heldItems.Length; j++)
            {
                // If I have found an item slot with the same item as the item that is going to be added
                if (targetItemSlot != null)
                {
                    // Stop the search
                    break;
                }

                // If the heldItem is the same with the item that is going to be added
                if (bags[i].heldItems[j].slottedItem == item)
                {
                    // Assign targetItemSlot to that item slot
                    targetItemSlot = bags[i].heldItems[j];

                    // If the stack number after adding is larger than the max stack number of that item
                    if (targetItemSlot.stackNumber + stackNumber > targetItemSlot.slottedItem.maxStackNumber)
                    {
                        // Reset targetItemSlot to search for another one
                        targetItemSlot = null;
                    }
                }
            }
        }

        // If a suitable item slot cannot be found yet
        if (targetItemSlot == null)
        {
            // Assign it to the closest empty item slot
            // For every bag
            for (int i = 0; i < bags.Count; i++)
            {
                // If I have found an item slot with the same item as the item that is going to be added
                if (targetItemSlot != null)
                {
                    // Stop the search
                    break;
                }

                // For eveny item in the bag
                for (int j = 0; j < bags[i].heldItems.Length; j++)
                {
                    // If the item slot is empty
                    if (bags[i].heldItems[j].slottedItem == null)
                    {
                        // Assign targetItemSlot to that item slot
                        targetItemSlot = bags[i].heldItems[j];

                        // Put the item in the slottedItem of that item slot
                        targetItemSlot.slottedItem = item;

                        // Change the sprite of that itemslot into the one of the item
                        inventoryBackground.GetChild(j).GetChild(0).GetComponent<Image>().sprite = bags[i].heldItems[j].slottedItem.itemIcon;

                        // Stop the search
                        break;
                    }
                }
            }
        }

        // Throw a debug message
        Debug.Log($"Adding {item.name} to {targetItemSlot}.");

        // Add the item
        targetItemSlot.slottedItem.Add(targetItemSlot, stackNumber);
    }

    public void ConsumeItem(Item item, int stackNumber)
    {
        // Throw a debug message
        Debug.Log($"Consuming {item.name} to {this.name}'s inventory.");

        // Cache the bags
        List<Container> bags = myInventory.bagSlots;

        // Initialize a temp item slot
        ItemSlot targetItemSlot = null;

        // Search for slot
        // For every bag
        for (int i = 0; i < bags.Count; i++)
        {
            // If I have found an item slot with the same item as the item that is going to be added
            if (targetItemSlot != null)
            {
                // Stop the search
                break;
            }

            // For eveny item in the bag
            for (int j = 0; j < bags[i].heldItems.Length; j++)
            {
                // If I have found an item slot with the same item as the item that is going to be added
                if (targetItemSlot != null)
                {
                    // Stop the search
                    break;
                }

                // If the heldItem is the same with the item that is going to be added
                if (bags[i].heldItems[j].slottedItem == item)
                {
                    // Assign targetItemSlot to that item slot
                    targetItemSlot = bags[i].heldItems[j];

                    // If the stack number after adding is less than 0
                    if (targetItemSlot.stackNumber - stackNumber < 0)
                    {
                        // Reset targetItemSlot to search for another one
                        targetItemSlot = null;
                    }
                }
            }
        }

        // If a suitable item slot cannot be found yet
        if (targetItemSlot == null)
        {
            // Throw an error message
            Debug.LogError("There is no such Item");
        }

        // Throw a debug message
        Debug.Log($"Consuming {item.name} in {targetItemSlot}.");

        // Add the item
        targetItemSlot.slottedItem.Consume(targetItemSlot, stackNumber);
    }

    // Method to display player's inventory
    public void OpenInventory()
    {
        // Throw a debug message
        Debug.Log($"Opening {this.name}'s inventory.");

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

                // Assign container to the inventory slots
                currentSlot.parent.GetComponent<InventorySlot>().heldItem = bags[i].heldItems[j];

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
