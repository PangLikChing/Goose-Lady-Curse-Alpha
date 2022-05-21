using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Item slottedItem = null;

    public int stackNumber = 0;

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
