using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// This script is responsible for handling the drop event for the inventory slots
/// </summary>

public class InventorySlot : MonoBehaviour, IDropHandler
{
    // This is the heldItem that the inventory slot is resposible for
    public ItemSlot heldItem;

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
            transform.GetChild(0).parent = originalInventorySlot.transform;
            originalInventorySlot.transform.GetChild(0).localPosition = new Vector2(0, 0);

            // Initialize a temp Item to store the slotted item in the dropped inventory slot
            Item newItem = heldItem.slottedItem;
            // Initialize a temp stack number to store the stack number in the dropped inventory slot
            int newStackNumber = heldItem.stackNumber;

            // Swap the slotted item and stack number for both inventory slots
            heldItem.slottedItem = originalInventorySlot.GetComponent<InventorySlot>().heldItem.slottedItem;
            heldItem.stackNumber = originalInventorySlot.GetComponent<InventorySlot>().heldItem.stackNumber;
            originalInventorySlot.heldItem.slottedItem = newItem;
            originalInventorySlot.heldItem.stackNumber = newStackNumber;
        }
    }
}
