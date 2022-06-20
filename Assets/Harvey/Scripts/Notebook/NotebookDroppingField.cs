using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NotebookDroppingField : MonoBehaviour, IDropHandler
{
    //[SerializeField] Image myImage;
    //[SerializeField] TMP_Text myTextField;

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log(eventData.pointerDrag.transform.GetComponent<NotebookDraggableWordBlock>());

        // If the left mouse button is responsible for the drop
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // If the dropped transform is a notebook suggested word block
            if (eventData.pointerDrag.transform.GetComponent<NotebookWordBlock>() != null)
            {
                // Cache the dropped word block
                NotebookWordBlock droppedNotebookWordBlock = eventData.pointerDrag.GetComponent<NotebookWordBlock>();

                // Throw a debug message
                Debug.Log("Dropped");

                // Set the parent of that word block to this dropping field
                droppedNotebookWordBlock.myClone.transform.SetParent(transform);

                // Set the position of the dropped word block
                droppedNotebookWordBlock.myClone.transform.localPosition = new Vector2(0, 0);
            }
        }
    }
}
