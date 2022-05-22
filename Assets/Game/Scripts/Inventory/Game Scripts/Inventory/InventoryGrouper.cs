using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script is responsible for managing the bags display
/// </summary>

[RequireComponent(typeof(GridLayoutGroup))]
public class InventoryGrouper : MonoBehaviour
{
    // myInventory is the inventory that this script is responsible for. Should assign somewhere else
    public Inventory myInventory;

    // bagGameObject is the UI prefeb for a bag
    public Transform bagTransform, inventorySlotTransform;

    // gridLayoutGroup is the gridLayoutGroup that the grouper is holding
    GridLayoutGroup gridLayoutGroup;

    void Start()
    {
        // Initialize
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
    }

    // If the inventory is opened
    void OnEnable()
    {
        // Initialize a temp int
        int largestBagSize = 0;

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

                // If the bag's size is larger than the largestBagSize temp int
                if (myInventory.bags[i].volume > largestBagSize)
                {
                    // Change largestBagSize to this bag's volume
                    largestBagSize = myInventory.bags[i].volume;
                }
            }

            // If the bag slot does not have a bag
            if (myInventory.itemList[i].Length == 0)
            {
                // Hide that bag on the screen
                newBag.gameObject.SetActive(false);
            }
        }

        // Refresh all the inventory slots display for that inventory
        myInventory.RefreshInventorySlots.Invoke();

        // Change the size of the grouper

        //gridLayoutGroup.cellSize = new Vector2(0, 0);

        // Change the position of the grouper
    }

    void OnDisable()
    {
        // For every child the grouper has
        for (int i = 0; i < transform.childCount; i++)
        {
            // Destory the child gameObject
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    // This is a method to refresh all inventory slots
    public void RefreshInventorySlots()
    {
        // If I am displaying the inventory slots
        if (gameObject.activeSelf == true)
        {
            // Throw a debug message
            Debug.Log("Refreshing all inventory slots");

            // For every bag
            for (int i = 0; i < myInventory.itemList.Count; i++)
            {
                // For every slot
                for (int j = 0; j < myInventory.itemList[i].Length; j++)
                {
                    // Cache the inventorySlot component for that inventory slot
                    InventorySlot currentInventorySlot = transform.GetChild(i).GetChild(j).GetComponent<InventorySlot>();

                    // If there is an item in the slot that I am responsible to display
                    if (myInventory.itemList[i][j].slottedItem != null)
                    {
                        // Get my slotted item and stack number updated
                        currentInventorySlot.slottedItem = myInventory.itemList[i][j].slottedItem;
                        currentInventorySlot.stackNumber = myInventory.itemList[i][j].stackNumber;

                        // Update the UI
                        currentInventorySlot.slottedItemImage.sprite = currentInventorySlot.slottedItem.itemIcon;
                        currentInventorySlot.stackNumberText.text = currentInventorySlot.stackNumber.ToString();

                        // If stack number is larger than or equal to 2
                        if (currentInventorySlot.stackNumber >= 2)
                        {
                            // Show the stack number text
                            currentInventorySlot.stackNumberText.gameObject.SetActive(true);
                        }
                    }
                    // If there is no item in the slot that I am responsible to display
                    else
                    {
                        // Reset slottedItem and stackNumber
                        currentInventorySlot.slottedItem = null;
                        currentInventorySlot.stackNumber = 0;

                        // Update the UI
                        currentInventorySlot.slottedItemImage.sprite = null;
                        currentInventorySlot.stackNumberText.text = currentInventorySlot.stackNumber.ToString();
                    }

                    // If stack number is less than or equal to 1
                    if (currentInventorySlot.stackNumber <= 1)
                    {
                        // Hide the stack number text
                        currentInventorySlot.stackNumberText.gameObject.SetActive(false);
                    }

                    // If this inventory slot doesn't have a slotted item
                    if (currentInventorySlot.slottedItem == null)
                    {
                        // If I have at least a item UI as a child
                        if (transform.childCount != 0)
                        {
                            // Disable the raycast for the slotted item so that the player cannot drag it
                            transform.GetChild(0).GetComponent<Image>().raycastTarget = false;
                        }
                    }
                    // Else
                    else
                    {
                        // If I have at least a item UI as a child
                        if (transform.childCount != 0)
                        {
                            // Enable the raycast for the slotted item so that the player can drag it
                            transform.GetChild(0).GetComponent<Image>().raycastTarget = true;
                        }
                    }
                }
            }
        }
    }
}
