using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This is the inventory Manager
/// </summary>

public class Inventory : MonoBehaviour
{
    // This is the bag scriptable objects that the player is currently holding. Should not change the data here
    public List<Container> bags = new List<Container>();

    // This is the items that the player is holding and its location
    public List<ItemSlot[]> itemList = new List<ItemSlot[]>();

    // boolean to check if the inventory is full or not
    bool isFull = false;

    // RefreshInventorySlots is an event to refresh all Inventory slots
    // Assign the responsible InventoryGrouper to this event and call RefreshInventorySlots()
    public UnityEvent RefreshInventorySlots;
    public UnityEvent CheckCraftable;
    public UnityEvent<bool> InventoryIsFull;

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

        // Check if the inventory is full
        if (IsInventoryFull() == true)
        {
            // If so, set isFull to true
            isFull = true;
        }
        else
        {
            // Else, set isFull to false
            isFull = false;
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

        // Check inventory state and invoke event accordingly
        CheckinventoryState();
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

        // Check inventory state and invoke event accordingly
        CheckinventoryState();
    }

    public void AddItemToSpecificSlot(InventorySlot inventorySlot, Item item, int stackNumber)
    {
        // Cache the targeted ItemSlot
        ItemSlot targetedItemSlot = itemList[inventorySlot.myBagIndex][inventorySlot.mySlotIndex];

        // If that slot does not have an item yet
        if (targetedItemSlot.slottedItem == null)
        {
            // Add the item to that slot
            targetedItemSlot.slottedItem = item;
            targetedItemSlot.stackNumber = stackNumber;
        }
        // Else if the slotted item is the same as the item specified
        else if (targetedItemSlot.slottedItem == item)
        {
            // If the stack combined will not exceed the max stack size
            if (targetedItemSlot.stackNumber + stackNumber <= targetedItemSlot.slottedItem.maxStackNumber)
            {
                // Add the 2 stacks
                targetedItemSlot.stackNumber += stackNumber;
            }
            // If the stack combined will exceed the max stack size
            else
            {
                // Do nothing
                return;
            }
        }
        // Else if the slotted item is not the sam as the item
        else
        {
            // Do nothing
            return;
        }

        // Check inventory state and invoke event accordingly
        CheckinventoryState();
    }

    public void RemoveItemFromSpecificSlot(InventorySlot inventorySlot, int stackNumber)
    {
        // Cache the targeted ItemSlot
        ItemSlot targetedItemSlot = itemList[inventorySlot.myBagIndex][inventorySlot.mySlotIndex];
        
        // If there are still item left in the stack after removal
        if (targetedItemSlot.stackNumber - stackNumber > 0)
        {
            // Only reduce the stack number
            targetedItemSlot.stackNumber = targetedItemSlot.stackNumber - stackNumber;
        }
        // If there is nothing left in the stack after removal
        else
        {
            // Remove the slotted item
            targetedItemSlot.slottedItem = null;

            // Reset the stack number
            targetedItemSlot.stackNumber = 0;
        }

        // Refresh that inventory slot
        inventorySlot.RefreshInventorySlot();

        // Check inventory state and invoke event accordingly
        CheckinventoryState();
    }

    public void SwapBag(int firstBag, int secondBag)
    {
        // Swap the item array in the data
        ItemSlot[] tempBag = itemList[firstBag];
        itemList[firstBag] = itemList[secondBag];
        itemList[secondBag] = tempBag;

        // Swap the bag
        Container tempContainer = bags[firstBag];
        bags[firstBag] = bags[secondBag];
        bags[secondBag] = tempContainer;
    }

    // Function to add a bag
    public void AddBag(ItemSlot itemSlot)
    {
        // Loop through all the bags
        for (int i = 0; i < bags.Count; i++)
        {
            // If there is a bag slot that is empty
            if (bags[i] == null)
            {
                // Try and see if that item is a container
                try
                {
                    // Add the bag to the bag slot
                    bags[i] = (Container)itemSlot.slottedItem;

                    // Throw a debug message
                    Debug.Log($"Adding {itemSlot.slottedItem.itemDisplayName} to the inventory");

                    // Assign an array for that new bag
                    itemList[i] = new ItemSlot[bags[i].volume];

                    // Create a number of itemslots in the array equals to the volume of the new bag
                    for (int j = 0; j < bags[i].volume; j++)
                    {
                        // Initialize a temp ItemSlot
                        ItemSlot tempItemSlot = new ItemSlot();

                        // Assign the temp ItemSlot to the itemSlots list
                        itemList[i][j] = tempItemSlot;
                    }

                    // Remove that bag from the inventory
                    itemSlot.slottedItem.Consume(itemSlot, 1);

                    // Throw a debug message
                    Debug.Log("This is a container");

                    // Stop the search
                    break;
                }
                catch
                {
                    // Throw a debug message
                    Debug.Log("This is not a container");
                }
            }
        }
    }

    // Function to add a bag to a specific bag slot
    public void AddBagToSpecificBagSlot(InventorySlot inventorySlot, int bagSlotIndex)
    {
        // If there is a bag slot that is empty
        if (bags[bagSlotIndex] == null)
        {
            // Try and see if that item is a container
            try
            {
                // Cache that item slot
                ItemSlot itemSlot = itemList[inventorySlot.myBagIndex][inventorySlot.mySlotIndex];

                // Add the bag to the bag slot
                bags[bagSlotIndex] = (Container)itemSlot.slottedItem;

                // Throw a debug message
                Debug.Log($"Adding {itemSlot.slottedItem.itemDisplayName} to the inventory");

                // Assign an array for that new bag
                itemList[bagSlotIndex] = new ItemSlot[bags[bagSlotIndex].volume];

                // Create a number of itemslots in the array equals to the volume of the new bag
                for (int j = 0; j < bags[bagSlotIndex].volume; j++)
                {
                    // Initialize a temp ItemSlot
                    ItemSlot tempItemSlot = new ItemSlot();

                    // Assign the temp ItemSlot to the itemSlots list
                    itemList[bagSlotIndex][j] = tempItemSlot;
                }

                // Remove that bag from the inventory
                itemSlot.slottedItem.Consume(itemSlot, 1);

                // Throw a debug message
                Debug.Log("This is a container");
            }
            catch
            {
                // Throw a debug message
                Debug.Log("This is not a container");
            }
        }
        // If that bag slot already has a bag
        else
        {
            // Try and see if that item is a container
            try
            {
                // Cache that item slot
                ItemSlot itemSlot = itemList[inventorySlot.myBagIndex][inventorySlot.mySlotIndex];

                // Cache the new bag
                Container newBag = (Container)itemSlot.slottedItem;

                // If the new bag's volume is larger than or equal to the current bag's volume
                if (newBag.volume >= bags[bagSlotIndex].volume)
                {
                    // Get the difference between the 2 bags
                    int difference = newBag.volume - bags[bagSlotIndex].volume;

                    // Add the bag to the bag slot
                    bags[bagSlotIndex] = (Container)itemSlot.slottedItem;

                    // Throw a debug message
                    Debug.Log($"Adding {itemSlot.slottedItem.itemDisplayName} to the inventory");

                    // Create a new array for the new bag
                    ItemSlot[] newItemArray = new ItemSlot[newBag.volume];

                    // Copy the old data to the array for that new bag
                    for (int i = 0; i < itemList[bagSlotIndex].Length; i++)
                    {
                        newItemArray[i] = itemList[bagSlotIndex][i];
                    }

                    // Create a number of itemslots in the array equals to the volume of the new bag
                    for (int j = 0; j < difference; j++)
                    {
                        // Initialize a temp ItemSlot
                        ItemSlot tempItemSlot = new ItemSlot();

                        // Assign the temp ItemSlot to the itemSlots list
                        newItemArray[itemList[bagSlotIndex].Length + j] = tempItemSlot;
                    }

                    // Replace the old array with the new array
                    itemList[bagSlotIndex] = newItemArray;
                }

                // Throw a debug message
                Debug.Log("This is a container");
            }
                catch
            {
                // Throw a debug message
                Debug.Log("This is not a container");
            }
        }
    }

    // Function to remove a bag from a bag slot to a specific inventory slot
    // Here assumes the max stack number of a container must be 1
    public void RemoveBag(InventorySlot inventorySlot, int bagSlotIndex)
    {
        // Assign that bag to the item slot
        itemList[inventorySlot.myBagIndex][inventorySlot.mySlotIndex].slottedItem = bags[bagSlotIndex];
        itemList[inventorySlot.myBagIndex][inventorySlot.mySlotIndex].stackNumber = bags[bagSlotIndex].maxStackNumber;

        // Remove the bag from the inventory
        bags[bagSlotIndex] = null;
        itemList[bagSlotIndex] = new ItemSlot[0];
    }

    // Function to see if a bag is empty
    // Returns true if a bag is empty
    public bool IsBagEmpty(int bagIndex)
    {
        // Loop though all the item slots in that bagIndex
        for (int i = 0; i < itemList[bagIndex].Length; i++)
        {
            // If there is an item in an item slot
            if (itemList[bagIndex][i].slottedItem != null)
            {
                // Return false
                return false;
            }
        }

        // Return true
        return true;
    }

    // Return true if the inventory is full
    public bool IsInventoryFull()
    {
        // For every bag
        for (int i = 0; i < itemList.Count; i++)
        {
            // For every item slot in the bag
            for (int j = 0; j < itemList[i].Length; j++)
            {
                // If the item slot does not contain an item
                if (itemList[i][j].slottedItem == null)
                {
                    // Return false as the bag is not full
                    return false;
                }
            }
        }
        // Return true as the bag is full
        return true;
    }

    // Method to check inventory state and invoke event accordingly
    void CheckinventoryState()
    {
        // Check if the inventory is full
        if (IsInventoryFull() == true && isFull == false)
        {
            // Invoke the event to tell other systems that the inventory is currently full
            InventoryIsFull.Invoke(true);

            // Notify the inventory that it is currently full
            isFull = true;
        }
        // If the inventory is not full now is it was full previously
        else if (IsInventoryFull() == false && isFull == true)
        {
            // Invoke the event to tell other systems that the inventory is currently not full
            InventoryIsFull.Invoke(false);

            // Notify the inventory that it is currently not full
            isFull = false;
        }
    }
}
