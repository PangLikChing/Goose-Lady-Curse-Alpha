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
