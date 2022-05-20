using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// This script is responsible for handling the drop event for the inventory slots
/// </summary>

public class InventorySlot : MonoBehaviour, IDropHandler
{
    // This is the heldItem that the inventory slot is resposible for
    [HideInInspector] public ItemSlot heldItem;

    public void OnDrop(PointerEventData eventData)
    {
        // If something is being dragged into the slot
        if (eventData.pointerDrag != null)
        {
            // Set it to my child
            eventData.pointerDrag.transform.SetParent(transform);

            // Snap that item into the slot
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

            // Cache the original inventory slot for the item getting dropped
            InventorySlot originalInventorySlot = eventData.pointerDrag.GetComponent<DragDrop>().originalInventorySlot;

            // Swap position for the 2 items
            transform.GetChild(0).SetParent(originalInventorySlot.transform);
            originalInventorySlot.transform.GetChild(0).localPosition = new Vector2(0, 0);

            // Cache the originalInventorySlotStackNumber
            int originalInventorySlotStackNumber = originalInventorySlot.GetComponent<InventorySlot>().heldItem.stackNumber;

            // If those 2 items in the slots are the same the sum of the 2 stack numbers will not exceed the max stack number of the item
            if (heldItem.slottedItem == originalInventorySlot.heldItem.slottedItem && heldItem.stackNumber + originalInventorySlotStackNumber < heldItem.slottedItem.maxStackNumber)
            {
                // Add stack number from the original inventory slots to the targeted slot
                heldItem.stackNumber += originalInventorySlotStackNumber;

                // Set the original slot's slottedItem to nothing and the stack number to 0
                originalInventorySlot.heldItem.slottedItem = null;
                originalInventorySlot.heldItem.stackNumber = 0;
            }
            else
            {
                // Initialize a temp Item to store the slotted item in the dropped inventory slot
                Item newItem = heldItem.slottedItem;
                // Initialize a temp stack number to store the stack number in the dropped inventory slot
                int newStackNumber = heldItem.stackNumber;

                // Swap the slotted item and stack number for both inventory slots
                heldItem.slottedItem = originalInventorySlot.GetComponent<InventorySlot>().heldItem.slottedItem;
                heldItem.stackNumber = originalInventorySlotStackNumber;
                originalInventorySlot.heldItem.slottedItem = newItem;
                originalInventorySlot.heldItem.stackNumber = newStackNumber;
            }
        }
    }
}
