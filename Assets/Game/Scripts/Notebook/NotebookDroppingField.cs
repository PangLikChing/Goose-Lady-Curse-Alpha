using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NotebookDroppingField : MonoBehaviour, IDropHandler
{
    NotebookManager notebookManager;

    void Start()
    {
        // Initialize
        notebookManager = FindObjectOfType<NotebookManager>();
    }

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

                // If I don't have a child clone draggable block
                if (transform.childCount == 0)
                {
                    // Snap the new clone's block to the centre of the dropping field
                    SnapBlock(clone.transform);
                }
                // If I have a child clone draggable block
                else
                {
                    // Cache the original clone block on the dropping field
                    NotebookDraggableWordBlock child = transform.GetChild(0).GetComponent<NotebookDraggableWordBlock>();

                    // Return the clone that was on the dropping field to the return field
                    notebookManager.returnDroppingField.ReturnBlock(child.myOriginalGameObject);

                    // Destory the clone that was in the dropping field
                    Destroy(child.gameObject);

                    // Snap the new clone's block to the centre of the dropping field
                    SnapBlock(clone.transform);
                }
            }
            // If the dropped transform is a notebook cloned word block
            else if (eventData.pointerDrag.GetComponent<NotebookDraggableWordBlock>() != null)
            {
                // Cache the clone word block
                NotebookDraggableWordBlock clone = eventData.pointerDrag.GetComponent<NotebookDraggableWordBlock>();

                // If I have a word block on me already
                if (transform.childCount > 0)
                {
                    // Swap the 2 blocks' parent
                    transform.GetChild(0).parent = clone.originalParent;
                    clone.transform.parent = transform;

                    // Snap them both into centre of their parents
                    clone.originalParent.GetChild(0).localPosition = new Vector2(0, 0);
                    clone.transform.localPosition = new Vector2(0, 0);
                }
                // If I do not have a word block on me
                else
                {
                    // Set the clone's parent to this dropping field
                    clone.transform.parent = transform;

                    // Snap the clone into the centre of this dropping field
                    clone.transform.localPosition = new Vector2(0, 0);
                }
            }
        }
    }

    private void SnapBlock(Transform cloneTransform)
    {
        // Set the parent of that word block to this dropping field
        cloneTransform.transform.SetParent(transform);

        // Set the position of the dropped word block
        cloneTransform.transform.localPosition = new Vector2(0, 0);

        // Enable the drag-ability of that dropped block clone
        cloneTransform.GetComponent<NotebookDraggableWordBlock>().canvasGroup.blocksRaycasts = true;
    }
}
