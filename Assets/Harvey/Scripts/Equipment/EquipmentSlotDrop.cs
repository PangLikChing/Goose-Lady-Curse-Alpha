using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EquipmentSlotDrop : MonoBehaviour, IDropHandler
{
    EquipmentSlotController equipmentSlotController;

    public UnityEvent<InventorySlot, int> removeFromInventory;

    public UnityEvent<InventorySlot, Item, int> unequipEquipment;

    void Start()
    {
        // Initialize
        equipmentSlotController = transform.GetChild(0).GetComponent<EquipmentSlotController>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        // If the left mouse button is responsible for the drop
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // If the dropped item is from the inventory
            if (eventData.pointerDrag.GetComponent<DragDrop>() != null)
            {
                try
                {
                    // Try to cast and store the slotted item as an equipment and see if that is actually an equipment or not
                    Equipment droppedEquipment = (Equipment)eventData.pointerDrag.GetComponent<DragDrop>().originalInventorySlot.slottedItem;

                    // Throw a debug message
                    Debug.Log("This is an equipment");

                    // If the equipment slot between the slot and the equipment are the same
                    if (equipmentSlotController.targetSlot == droppedEquipment.equipmentSlot)
                    {
                        // Throw a debug message
                        Debug.Log($"Equiping {droppedEquipment.itemDisplayName}");

                        // Cache the original inventory slot
                        InventorySlot droppedOriginalInventorySlot = eventData.pointerDrag.GetComponent<DragDrop>().originalInventorySlot;

                        // Remove that piece of equipment in the inventory
                        removeFromInventory.Invoke(droppedOriginalInventorySlot, 1);

                        // if the original equipment is not null
                        if (equipmentSlotController.targetSlot.equipment != null)
                        {
                            // Unequip the current equipment
                            unequipEquipment.Invoke(droppedOriginalInventorySlot, equipmentSlotController.targetSlot.equipment, 1);
                        }

                        // Equip the dropped equipment
                        equipmentSlotController.targetSlot.Equip(droppedEquipment);
                    }
                }
                    catch
                {
                    // Throw a debug message
                    Debug.Log("This is not an equipment");
                }
            }
        }
    }
}
