using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    // This is the bag scriptable objects that the player is currently holding. Should not change the data here
    public List<Container> bags = new List<Container>();

    // This is the items that the player is holding and its location
    public List<ItemSlot[]> itemList = new List<ItemSlot[]>();

    //public InventoryGrouper inventoryGrouper;

    // RefreshInventorySlots is an event to refresh all Inventory slots
    // Assign the responsible InventoryGrouper to this event and call RefreshInventorySlots()
    public UnityEvent RefreshInventorySlots;

    public UnityEvent CheckCraftable;

    // This should happen on start and on bag update, probaly should use an event for this
    void Awake()
    {
        // Initialize
        // For every bag that the player is carrying
        for (int i = 0; i < bags.Count; i++)
        {
            // If there is a bag in the bag slot
            if (bags[i] != null)
            {
                // Create a new empty array of ItemSlot with the bag size
                ItemSlot[] itemSlots = new ItemSlot[bags[i].volume];

                // Add that to the item list
                itemList.Add(itemSlots);

                // For every element in itemSlots
                for (int j = 0; j < itemSlots.Length; j++)
                {
                    // Initialize a temp ItemSlot
                    ItemSlot itemSlot = new ItemSlot();

                    // Assign the temp ItemSlot to the itemSlots list
                    itemSlots[j] = itemSlot;
                }
            }
            else
            {
                // Create a new empty array of ItemSlot with no element
                ItemSlot[] itemSlots = new ItemSlot[0];

                // Add that to the item list
                itemList.Add(itemSlots);
            }

            // Throw a debug message
            Debug.Log($"Added a itemslot array with the size of {itemList[i].Length}");
        }
    }

    // Method to search item in the player inventory
    public int SearchItem(Item item)
    {
        // Initialize a temp int
        int count = 0;

        // For every bag
        for (int i = 0; i < itemList.Count; i++)
        {
            // For every slot
            for (int j = 0; j < itemList[i].Length; j++)
            {
                // If the slotted item in that slot is the same with the targeted item
                if (itemList[i][j].slottedItem == item)
                {
                    // Add the stack number to the temp int
                    count += itemList[i][j].stackNumber;
                }
            }
        }

        // Return the temp int
        return count;
    }


    public void AddItem(Item item, int stackNumber)
    {
        // Throw a debug message
        Debug.Log($"Adding {stackNumber} {item.name}(s) to the inventory");

        // Initialize a temp ItemSlot
        ItemSlot targetItemSlot = null;

        // Search for an existing same item
        // For every bag in player's inventory
        for (int i = 0; i < itemList.Count; i++)
        {
            // If we have found a suitable item slot
            if (targetItemSlot != null)
            {
                // Stop the search
                break;
            }

            // For every ItemSlot in that bag
            for (int j = 0; j < itemList[i].Length; j++)
            {
                // If there is an item in that ItemSlot
                if (itemList[i][j].slottedItem != null)
                {
                    // If that slottedItem in that ItemSlot is the same as item getting added
                    // and will not exceed the stack's max stack number if we add those 2 together
                    if (itemList[i][j].slottedItem == item && itemList[i][j].stackNumber + stackNumber <= itemList[i][j].slottedItem.maxStackNumber)
                    {
                        // That item slot will be the item slot we need to find
                        targetItemSlot = itemList[i][j];

                        // Throw a debug message
                        Debug.Log($"Adding {stackNumber} {item.name}(s) to bag {i} slot {j}");
                    }
                }
            }
        }

        // If I cannot find an exsiting slot
        if (targetItemSlot == null)
        {
            // Search for an empty slot
            // For every bag in player's inventory
            for (int i = 0; i < itemList.Count; i++)
            {
                // If we have found a suitable item slot
                if (targetItemSlot != null)
                {
                    // Stop the search
                    break;
                }

                // For every ItemSlot in that bag
                for (int j = 0; j < itemList[i].Length; j++)
                {
                    // If there is no item in that ItemSlot
                    if (itemList[i][j].slottedItem == null)
                    {
                        // That item slot will be the item slot we need to find
                        targetItemSlot = itemList[i][j];

                        // Throw a debug message
                        Debug.Log($"Adding {stackNumber} {item.name}(s) to bag {i} slot {j}");

                        // Stop the search
                        break;
                    }
                }
            }
        }

        // If I cannot find a suitable item slot, aka the inventory is full
        if (targetItemSlot == null)
        {
            // Throw a debug message
            Debug.Log("Inventory is full.");
        }
        // If I can find a suitable item slot
        else
        {
            // Add the item to the inventory
            targetItemSlot.slottedItem = item;
            item.Add(targetItemSlot, stackNumber);
        }

        // Refresh Inventory slots
        RefreshInventorySlots.Invoke();

        // Check if the item is craftable
        CheckCraftable.Invoke();
    }

    public void ConsumeItem(Item item, int stackNumber)
    {
        // Throw a debug message
        Debug.Log($"Consuming {stackNumber} {item.name}(s) to the inventory");

        // Initialize a temp ItemSlot
        ItemSlot targetItemSlot = null;

        // Search for an existing same item
        // For every bag in player's inventory
        for (int i = 0; i < itemList.Count; i++)
        {
            // If we have found a suitable item slot
            if (targetItemSlot != null)
            {
                // Stop the search
                break;
            }

            // For every ItemSlot in that bag
            for (int j = 0; j < itemList[i].Length; j++)
            {
                // If there is an item in that ItemSlot
                if (itemList[i][j].slottedItem != null)
                {
                    // If that slottedItem in that ItemSlot is the same as item getting consumed
                    // and will not become less than 0 after consumption
                    if (itemList[i][j].slottedItem == item && itemList[i][j].stackNumber - stackNumber >= 0)
                    {
                        // That item slot will be the item slot we need to find
                        targetItemSlot = itemList[i][j];

                        // Throw a debug message
                        Debug.Log($"Consuming {stackNumber} {item.name}(s) in bag {i} slot {j}");

                        // Stop the search
                        break;
                    }
                }
            }
        }

        // If I can find a suitable item slot
        if (targetItemSlot != null)
        {
            if (targetItemSlot.stackNumber - stackNumber >= 0)
            {
                // Consume the item to the inventory
                item.Consume(targetItemSlot, stackNumber);
            }
            else
            {
                // Initialize a temp int to save the stack number on the stack that doesn't have enough item stack number
                int remainder = targetItemSlot.stackNumber;

                // Consume the whole stack
                item.Consume(targetItemSlot, targetItemSlot.stackNumber);

                // Consume the other item stack
                ConsumeItem(item, stackNumber - remainder);
            }

            // Refresh Inventory slots
            RefreshInventorySlots.Invoke();
        }
        // If I cannot find a suitable item slot, aka there is no such item in the inventory
        else
        {
            // Throw a debug message
            Debug.Log("There is no such item in the inventory.");
        }

        // Refresh Inventory slots
        RefreshInventorySlots.Invoke();
    }
}
