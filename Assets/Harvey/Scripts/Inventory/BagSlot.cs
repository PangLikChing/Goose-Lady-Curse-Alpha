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
        Debug.Log("Yo");

        // Swap bag
        swapBag.Invoke(eventData.pointerDrag.GetComponent<BagSlotDragDrop>().bagIndex, bagIndex);
    }
}
