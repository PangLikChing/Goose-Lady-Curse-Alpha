using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NotebookDroppingField : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        // If the left mouse button is responsible for the drop
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // If the dropped transform is a notebook suggested word block
            if (eventData.pointerDrag.GetComponent<NotebookWordBlock>() != null)
            {
                // Cache the dropped word block clone
                NotebookDraggableWordBlock clone = eventData.pointerDrag.GetComponent<NotebookWordBlock>().myClone;

                // Throw a debug message
                Debug.Log("Dropped");

                // Set the parent of that word block to this dropping field
                clone.transform.SetParent(transform);

                // Set the position of the dropped word block
                clone.transform.localPosition = new Vector2(0, 0);

                // Enable the drag-ability of that dropped block clone
                clone.GetComponent<NotebookDraggableWordBlock>().canvasGroup.blocksRaycasts = true;
            }
        }
    }
}
