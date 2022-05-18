using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public ItemSlot itemSlot;

    public void OnDrop(PointerEventData eventData)
    {
        // If something is being dragged into the slot
        if (eventData.pointerDrag != null)
        {
            // Set it to my child
            eventData.pointerDrag.transform.SetParent(transform);

            // Snap that item into the slot
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        }
    }
}
