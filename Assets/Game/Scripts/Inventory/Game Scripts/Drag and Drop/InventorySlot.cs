using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Item slottedItem = null;

    public int stackNumber = 0;

    // myInventory is the inventory that the slot is in
    [SerializeField] Inventory myInventory;

    [SerializeField] int myBagIndex, mySlotIndex;

    public Image slottedItemImage;

    public TMP_Text stackNumberText;

    void Start()
    {
        // Initialize
        myInventory = transform.parent.parent.GetComponent<InventoryGrouper>().myInventory;

        // Find out which bag I am in
        for (int i = 0; i < transform.parent.parent.childCount; i++)
        {
            if (transform.parent.parent.GetChild(i).transform == transform.parent)
            {
                myBagIndex = i;
            }
        }

        // Find out which slot I am at
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            if (transform.parent.GetChild(i).transform == transform)
            {
                mySlotIndex = i;
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        // Cache the dropped transform
        Transform droppedTransform = eventData.pointerDrag.transform;

        // If dropped transform's parent is not its original inventory slot
        if (droppedTransform.parent != droppedTransform.GetComponent<DragDrop>().originalInventorySlot)
        {
            // Throw a debug message
            Debug.Log("Dropped");

            // Cache the inventory slot of the dropped item
            InventorySlot originalInventorySlot = droppedTransform.GetComponent<DragDrop>().originalInventorySlot;

            // Cache the Item slot of the dropped item in the inventory
            ItemSlot originalItemSlot = myInventory.itemList[originalInventorySlot.myBagIndex][originalInventorySlot.mySlotIndex];

            // Cache my own Item slot in the inventory
            ItemSlot myItemSlot = myInventory.itemList[myBagIndex][mySlotIndex];

            // If they are the same item and adding them up will not exceed the item's max stack number
            if (originalItemSlot.slottedItem == myItemSlot.slottedItem
                && myItemSlot.stackNumber + originalItemSlot.stackNumber <= myItemSlot.slottedItem.maxStackNumber)
            {
                // Carry out the add event for that item
                slottedItem.Add(myItemSlot, originalItemSlot.stackNumber);

                // Reset originalItemSlot's inventory data
                originalItemSlot.slottedItem = null;
                originalItemSlot.stackNumber = 0;
            }
            // If they are not same item or adding the 2 same item up will not exceed the item's max stack number
            else
            {
                // Swap the data in the inventory
                // Initialize a temp ItemSlot
                ItemSlot tempItemSlot = new ItemSlot();

                // Swap
                tempItemSlot.slottedItem = originalItemSlot.slottedItem;
                tempItemSlot.stackNumber = originalItemSlot.stackNumber;
                originalItemSlot.slottedItem = slottedItem;
                originalItemSlot.stackNumber = stackNumber;
                myItemSlot.slottedItem = tempItemSlot.slottedItem;
                myItemSlot.stackNumber = tempItemSlot.stackNumber;

                // Refresh the inventory slots invovled in the swap / stack
                originalInventorySlot.RefreshInventorySlot();
                RefreshInventorySlot();
            }
        }
    }

    // Method to refresh a single inventory slot
    public void RefreshInventorySlot()
    {
        // If there is an item in the slot that I am responsible to display
        if (myInventory.itemList[myBagIndex][mySlotIndex].slottedItem != null)
        {
            // Get my slotted item and stack number updated
            slottedItem = myInventory.itemList[myBagIndex][mySlotIndex].slottedItem;
            stackNumber = myInventory.itemList[myBagIndex][mySlotIndex].stackNumber;

            // Update the UI
            slottedItemImage.sprite = slottedItem.itemIcon;
            stackNumberText.text = stackNumber.ToString();

            // If stack number is larger than or equal to 2
            if (stackNumber >= 2)
            {
                // Show the stack number text
                stackNumberText.gameObject.SetActive(true);
            }
        }
        // If there is no item in the slot that I am responsible to display
        else
        {
            // Reset slottedItem and stackNumber
            slottedItem = null;
            stackNumber = 0;

            // Update the UI
            slottedItemImage.sprite = null;
            stackNumberText.text = stackNumber.ToString();
        }

        // If stack number is less than or equal to 1
        if (stackNumber <= 1)
        {
            // Hide the stack number text
            stackNumberText.gameObject.SetActive(false);
        }

        // If this inventory slot doesn't have a slotted item
        if (slottedItem == null)
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
