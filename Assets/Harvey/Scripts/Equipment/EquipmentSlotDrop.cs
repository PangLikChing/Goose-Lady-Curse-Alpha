using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlotDrop : MonoBehaviour, IDropHandler
{
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
                    // Try to cast the slotted item as an equipment and see if that is actually an equipment or not
                    Equipment droppedEquipment = (Equipment)eventData.pointerDrag.GetComponent<DragDrop>().originalInventorySlot.slottedItem;

                    // Compare the slotNumber between the slot and the equipment

                    // Equip it if they are the same

                    // Throw a debug message
                    Debug.Log("This is an equipment");
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
