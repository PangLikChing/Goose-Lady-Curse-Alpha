using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    [HideInInspector] public Item slottedItem = null;

    [HideInInspector] public int stackNumber = 0;

    // myInventory is the inventory that the slot is in
    public Inventory myInventory;

    [HideInInspector] public int myBagIndex, mySlotIndex;

    public Image slottedItemImage;

    public TMP_Text stackNumberText;

    public UnityEvent<InventorySlot, int> removeBag;

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

        // Refresh the inventory slot
        RefreshInventorySlot();
    }

    public void OnDrop(PointerEventData eventData)
    {
        // If the left mouse button is responsible for the drop
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // If the dropped item is an inventory item image
            if (eventData.pointerDrag.GetComponent<DragDrop>() != null)
            {
                // Cache the dropped transform
                Transform droppedTransform = eventData.pointerDrag.transform;

                // If dropped inventory slot is not its original inventory slot
                if (droppedTransform != droppedTransform.GetComponent<DragDrop>().originalInventorySlot)
                {
                    // Throw a debug message
                    Debug.Log("Dropped");

                    // Set the dropped item's parent back to the original inventory slot
                    droppedTransform.parent = droppedTransform.GetComponent<DragDrop>().originalInventorySlot.transform;

                    // Snap the droppedTransform to the centre of the the original inventory slot
                    droppedTransform.localPosition = new Vector2(0, 0);

                    // Cache the inventory slot of the dropped item
                    InventorySlot originalInventorySlot = droppedTransform.GetComponent<DragDrop>().originalInventorySlot;

                    // Cache the Item slot of the dropped item in the inventory
                    ItemSlot originalItemSlot = myInventory.itemList[originalInventorySlot.myBagIndex][originalInventorySlot.mySlotIndex];

                    // Cache my own Item slot in the inventory
                    ItemSlot myItemSlot = myInventory.itemList[myBagIndex][mySlotIndex];

                    // If they are responsible to 2 different item slots
                    if (originalItemSlot != myItemSlot)
                    {
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

                            // Refresh this inventory slot
                            RefreshInventorySlot();
                        }
                    }
                }
            }
            // Else if that dropped item is a bag slot image instead
            else if (eventData.pointerDrag.GetComponent<BagSlotDragDrop>() != null)
            {
                // If there is no item currently in the inventory slot
                if (slottedItem == null)
                {
                    // Cache the BagSlotDragDrop of that dropped item
                    BagSlotDragDrop bagSlotDragDrop = eventData.pointerDrag.GetComponent<BagSlotDragDrop>();

                    // If that bag which the bag image is representing is empty
                    if (myInventory.IsBagEmpty(bagSlotDragDrop.bagIndex))
                    {
                        // If that bag isn't the bag it is representing
                        if (bagSlotDragDrop.bagIndex != myBagIndex)
                        {
                            // Remove that bag from the bag slot
                            removeBag.Invoke(this, bagSlotDragDrop.bagIndex);
                        }
                    }
                    // If there is something in that bag
                    else
                    {
                        // Throw a warning message
                        Debug.Log("There is something in this bag");
                    }
                }
                // If there is something currently in this inventory slot
                else
                {
                    // Throw a debug message
                    Debug.Log("There is something in this inventory slot");
                }
            }
            // Else if the dropped item is from the equipment menu
            else if (eventData.pointerDrag.GetComponent<EquipmentDragDrop>() != null)
            {
                Debug.Log("Equipment dropped");

                // If the slot is empty
                if (slottedItem == null)
                {
                    //// Try to cache the equipment slot
                    try
                    {
                        // Cache the equipment slot
                        EquipmentSlot droppedEquipment = eventData.pointerDrag.GetComponent<EquipmentSlotController>().targetSlot;

                        // Add that item to the inventory
                        myInventory.AddItemToSpecificSlot(this, droppedEquipment.equipment, 1);

                        // Refresh the inventory slot
                        RefreshInventorySlot();

                        // Unequip the equipment in the equipment menu
                        droppedEquipment.UnEquip();
                    }
                        catch
                    {
                        // Throw a debug message
                        Debug.Log("There is no equipment slot");
                    }
                }
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

            // If the transform has child / children, aka there is a item iamge there
            if (transform.childCount > 0)
            {
                // Turn on the block raycast
                transform.GetChild(0).GetComponent<CanvasGroup>().blocksRaycasts = true;
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

            // If there is a child image item
            if (transform.childCount != 0)
            {
                // Turn off the block raycast
                transform.GetChild(0).GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
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
                transform.GetChild(0).GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }
        // Else
        else
        {
            // If I have at least a item UI as a child
            if (transform.childCount != 0)
            {
                // Enable the raycast for the slotted item so that the player can drag it
                transform.GetChild(0).GetComponent<CanvasGroup>().blocksRaycasts = true;
            }
        }
    }
}
