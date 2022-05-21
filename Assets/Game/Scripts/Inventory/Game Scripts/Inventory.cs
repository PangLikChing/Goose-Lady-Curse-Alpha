using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Inventory is the bags that the player is carrying
/// </summary>

public class Inventory : MonoBehaviour
{
    public List<Container> bags = new List<Container>();

    [SerializeField] Transform inventoryBackground;

    public UnityEvent Open;

    void Start()
    {
        // For every bag of the player
        for (int i = 0; i < bags.Count; i++)
        {
            // For every itemSlot in the bag
            for (int j = 0; j < bags[i].heldItems.Length; j++)
            {
                Debug.Log(bags[i].heldItems.Length);
                // Create an enpty ItemSlot
                bags[i].heldItems[j] = new ItemSlot();

                // Load the data
            }
        }
    }

    public void AddItem(Item item, int stackNumber)
    {
        // Throw a debug message
        Debug.Log($"Adding {item.name} to {this.name}'s inventory.");

        // Initialize a temp itemSlot
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
                    // Assign targetItemSlot to that inventory slot
                    targetItemSlot = bags[i].heldItems[j];

                    // If the stack number after adding is larger than the max stack number of that item
                    if (bags[i].heldItems[j].stackNumber + stackNumber > bags[i].heldItems[j].slottedItem.maxStackNumber)
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

        // event
    }

    public void ConsumeItem(Item item, int stackNumber)
    {
        // Throw a debug message
        Debug.Log($"Consuming {item.name} to {this.name}'s inventory.");

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

    // Method to spilt item
    public void SpiltItem(InventorySlot targetInventorySlot, int spiltStackNumber)
    {
        // Throw a debug message
        Debug.Log($"Spilting {targetInventorySlot.name} by {spiltStackNumber} in {this.name}'s inventory.");

        // Initialize a temp ItemSlot for the upcoming empty ItemSlot
        ItemSlot emptyItemSlot = null;

        // Search for closest empty item slot
        // Assign it to the closest empty item slot
        // For every bag
        for (int i = 0; i < bags.Count; i++)
        {
            // If I have found an item slot with the same item as the item that is going to be added
            if (emptyItemSlot != null)
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
                    // Assign the emptyItemSlot to the slot found
                    emptyItemSlot = bags[i].heldItems[j];

                    // Stop the search
                    break;
                }
            }
        }

        // If I find an empty ItemSlot
        if (emptyItemSlot != null)
        {
            // Spilt the stack
            emptyItemSlot.slottedItem = targetInventorySlot.slottedItem;
            targetInventorySlot.stackNumber -= spiltStackNumber;
            emptyItemSlot.stackNumber = spiltStackNumber;
        }
        // If I do not find an empty ItemSlot
        else
        {
            // Throw a debug message
            Debug.Log("The bag is full");
        }
    }

    // Method to display player's inventory
    public void OpenInventory()
    {
        // Throw a debug message
        Debug.Log($"Opening {this.name}'s inventory.");

        // Read Data
        // For every bag
        for (int i = 0; i < bags.Count; i++)
        {
            // For eveny item in the bag
            for (int j = 0; j < bags[i].heldItems.Length; j++)
            {
                // If there is an item
                if (bags[i].heldItems[j] != null)
                {
                    // Cache the current inventory slot
                    Transform currentSlot = inventoryBackground.GetChild(j).GetChild(0);

                    // Assign container to the inventory slots
                    currentSlot.parent.GetComponent<InventorySlot>().slottedItem = bags[i].heldItems[j].slottedItem;
                    currentSlot.parent.GetComponent<InventorySlot>().stackNumber = bags[i].heldItems[j].stackNumber;

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
}
