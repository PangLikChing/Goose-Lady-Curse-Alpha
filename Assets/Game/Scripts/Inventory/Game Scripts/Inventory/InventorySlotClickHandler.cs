using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotClickHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Inventory myInventory;

    void Start()
    {
        // Initialize
        myInventory = transform.parent.parent.parent.GetComponent<InventoryGrouper>().myInventory;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // If that is a right click
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            // Throw a debug message
            Debug.Log($"Right click on {gameObject.name}");

            // Cache my inventory slot
            InventorySlot myInventorySlot = transform.parent.GetComponent<InventorySlot>();

            // Get my item slot
            ItemSlot myItemSlot = myInventory.itemList[myInventorySlot.myBagIndex][myInventorySlot.mySlotIndex];

            // Use that item / consumable / equipment in the item slot
            transform.parent.GetComponent<InventorySlot>().slottedItem.Use(myItemSlot);

            myInventory.RefreshInventorySlots.Invoke();
        }
    }
}
