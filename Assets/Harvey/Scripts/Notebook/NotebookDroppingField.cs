using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NotebookDroppingField : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        // If the left mouse button is responsible for the drop
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Cache the dropped word block's transform
            Transform droppedTransform = eventData.pointerDrag.transform;

            // Throw a debug message
            Debug.Log("Dropped");

            // Set the parent of that word block to this dropping field
            droppedTransform.SetParent(transform);

            // Set the position of the dropped word block
            droppedTransform.localPosition = new Vector2(0, 0);
        }
    }
}
