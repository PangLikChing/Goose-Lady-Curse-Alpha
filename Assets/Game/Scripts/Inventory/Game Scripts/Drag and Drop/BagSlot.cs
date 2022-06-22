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

    public UnityEvent<int> refreshBag;

    public UnityEvent<int, int> swapBag, increaseInventorySlots;

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
            // If my child has an image, aka there is a bag in the bag slot
            if (transform.GetChild(0).GetComponent<Image>().sprite == null)
            {
                // Cache that dropped originalInventorySlot
                InventorySlot originalInventorySlot = eventData.pointerDrag.GetComponent<DragDrop>().originalInventorySlot;

                // Try to add that bag to this bag slot
                addBagToSpecificSlot.Invoke(originalInventorySlot, bagIndex);

                // Assign bag image to match that in player's bag
                AssignBagImage();

                // Turn on block raycast for that bag
                transform.GetChild(0).GetComponent<CanvasGroup>().blocksRaycasts = true;

                // Open the bag in that bag index
                refreshBag.Invoke(bagIndex);
            }
            else
            {
                // Throw a debug message
                Debug.Log("There is a bag in the slot");

                // Try to cast the dropped item as a container
                try
                {
                    // Cache the container
                    Container newBag = (Container)eventData.pointerDrag.GetComponent<DragDrop>().originalInventorySlot.slottedItem;

                    // If the new bag's volume is larger than the player's current bag
                    if (newBag.volume >= playerInventory.bags[bagIndex].volume)
                    {
                        // Get the difference between the 2 bags
                        int difference = newBag.volume - playerInventory.bags[bagIndex].volume;

                        // Throw a debug message
                        Debug.Log("Should Swap bag here");

                        // Cache the original inventory slot for the dropped item
                        InventorySlot droppedOriginalInventorySlot = eventData.pointerDrag.GetComponent<DragDrop>().originalInventorySlot;

                        // Reference the old bag
                        Container oldBag = playerInventory.bags[bagIndex];

                        // Add the new bag to the bag slot
                        addBagToSpecificSlot.Invoke(droppedOriginalInventorySlot, bagIndex);

                        // Assign bag image to match that in player's bag
                        AssignBagImage();

                        // Put the old bag to the original bag slot that the dropped item was at
                        playerInventory.itemList[droppedOriginalInventorySlot.myBagIndex][droppedOriginalInventorySlot.mySlotIndex].slottedItem = oldBag;

                        // Instantiate new inventory slots for every new inventory slot
                        increaseInventorySlots.Invoke(bagIndex, difference);
                    }
                }
                    // If it is not a container
                    catch
                {
                    // Throw a debug message
                    Debug.Log("That is not a container!");
                }
            }
        }
    }
}
