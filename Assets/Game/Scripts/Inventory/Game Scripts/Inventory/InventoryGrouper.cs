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

    public Canvas canvas;

    // gridLayoutGroup is the GridLayoutGroup that the grouper is holding
    GridLayoutGroup gridLayoutGroup;

    // rectTransform is the RectTransform that the grouper is holding
    RectTransform rectTransform;

    void Awake()
    {
        // Initialize
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();
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
                    // Instantiate a new inventory slot gameObject
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
                newBag.GetComponent<CanvasGroup>().alpha = 0;

                // Change the layer of the bag to the default layer
                newBag.gameObject.layer = 0;
            }
        }

        // Go to the right position and scale to the right size
        ScaleInventoryGrouper();
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

    public void IncreaseInventorySlots(int bagIndex, int numberOfNewSlots)
    {
        // Cache the targeted bag
        Transform bag = transform.GetChild(bagIndex);

        // For every element in the bag
        for (int i = 0; i < numberOfNewSlots; i++)
        {
            // Instantiate a new inventory slot gameObject as a child of the bag display
            Instantiate(inventorySlotTransform, bag);
        }
    }

    public void OpenBag(int bagIndex)
    {
        // Cache the targeted bag
        GameObject bag = transform.GetChild(bagIndex).gameObject;

        // Show that bag on the screen
        bag.GetComponent<CanvasGroup>().alpha = 1;

        // Change the layer of the bag to the UI layer
        bag.gameObject.layer = LayerMask.NameToLayer("UI");

        // For every element in the bag
        for (int i = 0; i < myInventory.bags[bagIndex].volume; i++)
        {
            // Instantiate a new inventory slot gameObject as a child of the bag display
            Instantiate(inventorySlotTransform, bag.transform);
        }
    }

    // Method to scale this gameObject
    // This assume every bag has the same size in terms of UI
    private void ScaleInventoryGrouper()
    {
        // Find out how many bag's UI gameObject is active
        // and find the largest bag
        // Initialize 2 temp ints
        int numberOfBagActive = 0, largestBagIndex = 0;

        // For every bag
        for (int i = 0; i < transform.childCount; i++)
        {
            // If that bag's UI gameObject is active
            if (transform.GetChild(i).gameObject.activeSelf == true)
            {
                // Increment the temp int
                numberOfBagActive++;

                // If that bag's child count is larger than that of the current largest bag's child count
                if (transform.GetChild(i).childCount > transform.GetChild(largestBagIndex).childCount)
                {
                    // Update the lagestBagIndex
                    largestBagIndex = i;
                }
            }
        }

        // Cache the bag's GridLayoutGroup
        GridLayoutGroup bagGridLayoutGroup = transform.GetChild(largestBagIndex).GetComponent<GridLayoutGroup>();

        // Cache the number of columns for a bag
        int bagNumberOfColumns = bagGridLayoutGroup.constraintCount;

        // Calculate the number of rows that the grid for a bag currently has
        int bagNumberOfRows = bagGridLayoutGroup.transform.childCount / bagNumberOfColumns;

        // If the remainder is not 0
        if (bagGridLayoutGroup.transform.childCount % bagGridLayoutGroup.constraintCount != 0)
        {
            // Increase the amount of rows by 1
            bagNumberOfRows++;
        }

        // Calculate the cell size
        gridLayoutGroup.cellSize = new Vector2(bagGridLayoutGroup.cellSize.x * bagGridLayoutGroup.constraintCount + bagGridLayoutGroup.spacing.x * bagGridLayoutGroup.constraintCount + bagGridLayoutGroup.padding.left - bagGridLayoutGroup.padding.right
                                                , (bagGridLayoutGroup.cellSize.y + bagGridLayoutGroup.spacing.y) * bagNumberOfRows + bagGridLayoutGroup.padding.top - bagGridLayoutGroup.padding.bottom);

        // Calculate the new x size value
        float newSizeDeltaX = bagGridLayoutGroup.padding.left + (int)bagGridLayoutGroup.cellSize.x * bagNumberOfColumns + bagGridLayoutGroup.spacing.x * bagNumberOfColumns;

        // Calculate the new y size value
        float newSizeDeltaY = bagGridLayoutGroup.padding.top + (int)bagGridLayoutGroup.cellSize.y * bagNumberOfRows + (bagGridLayoutGroup.spacing.y + gridLayoutGroup.spacing.y) * bagNumberOfRows;

        // Change the rect transform's sizeDelta
        rectTransform.sizeDelta = new Vector2(newSizeDeltaX, newSizeDeltaY);

        // Change the position of the grid
        rectTransform.anchoredPosition = new Vector3(-newSizeDeltaX - bagGridLayoutGroup.cellSize.x, newSizeDeltaY * numberOfBagActive + bagGridLayoutGroup.cellSize.y, 0);
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
                        if (currentInventorySlot.transform.childCount != 0)
                        {
                            // Disable the raycast for the slotted item so that the player cannot drag it
                            currentInventorySlot.transform.GetChild(0).GetComponent<CanvasGroup>().blocksRaycasts = false;
                        }
                    }
                    // Else
                    else
                    {
                        // If I have at least a item UI as a child
                        if (currentInventorySlot.transform.childCount != 0)
                        {
                            // Enable the raycast for the slotted item so that the player can drag it
                            currentInventorySlot.transform.GetChild(0).GetComponent<CanvasGroup>().blocksRaycasts = true;
                        }
                    }
                }
            }
        }
    }
}
