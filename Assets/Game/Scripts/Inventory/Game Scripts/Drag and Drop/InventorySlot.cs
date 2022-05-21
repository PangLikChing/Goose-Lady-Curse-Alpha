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

    [SerializeField] Image slottedItemImage;

    [SerializeField] TMP_Text stackNumberText;

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

    //test
    void LateUpdate()
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
    }
    //test

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
