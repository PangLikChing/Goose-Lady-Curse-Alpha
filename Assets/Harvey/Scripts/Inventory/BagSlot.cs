using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BagSlot : MonoBehaviour, IDropHandler
{
    // Which bag I am responsible for, assigned when instantiated by BagSlotsUI
    public int bagIndex;
    
    // Which inventory I am responsible for, assigned when instantiated by BagSlotsUI
    public Inventory playerInventory;

    public UnityEvent<int, int> swapBag;

    public UnityEvent<InventorySlot, int> addBagToSpecificSlot;

    public void AssignBagImage()
    {
        // If there is a bag in that slot
        if (playerInventory.bags[bagIndex] != null)
        {
            // Assign bag icon to the bag image based on which bag this bag slot is responsible for
            transform.GetChild(0).GetComponent<Image>().sprite = playerInventory.bags[bagIndex].itemIcon;
        }
        else
        {
            // Disable blocksRaycasts to prevent player from dragging the bag image
            transform.GetChild(0).GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        // If the dropped item is a bag slot image
        if (eventData.pointerDrag.GetComponent<BagSlotDragDrop>() != null)
        {
            // If that dropped bag slot image is not representing the same bag as this bag slot
            if (eventData.pointerDrag.GetComponent<BagSlotDragDrop>().bagIndex != bagIndex)
            {
                // Swap bag
                swapBag.Invoke(eventData.pointerDrag.GetComponent<BagSlotDragDrop>().bagIndex, bagIndex);
            }
        }
        // If the dropped item is an inventory slot image
        else if (eventData.pointerDrag.GetComponent<DragDrop>() != null)
        {
            //temp
            eventData.pointerDrag.GetComponent<DragDrop>().shouldNotDrop = true;
            //temp

            // Try to add that bag to this bag slot
            addBagToSpecificSlot.Invoke(eventData.pointerDrag.GetComponent<DragDrop>().originalInventorySlot, bagIndex);
        }
    }
}
