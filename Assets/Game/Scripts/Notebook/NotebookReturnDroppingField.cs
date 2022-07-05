using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Behaviour script for the dropping field in the words to choose from column in the notebook menu
/// </summary>

public class NotebookReturnDroppingField : MonoBehaviour, IDropHandler
{
    // The scroll view content that I am responsible for
    [SerializeField] Transform myContent;

    public void OnDrop(PointerEventData eventData)
    {
        // If the left mouse button is responsible for the drop
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Throw a debug message
            Debug.Log("Right Dropped");

            // If the clone is dropped on top of this dropping field
            if (eventData.pointerDrag.GetComponent<NotebookDraggableWordBlock>() != null)
            {
                Debug.Log("Do something");

                // Cache the original game object of the dropped clone object
                GameObject originalGameObject = eventData.pointerDrag.GetComponent<NotebookDraggableWordBlock>().myOriginalGameObject;

                // Find the original gameObject
                ReturnBlock(originalGameObject);

                // Destory that clone
                Destroy(eventData.pointerDrag.gameObject);

                // Disable this game object to allow dragging of words suggestion blocks again
                gameObject.SetActive(false);
            }
        }
    }

    public void ReturnBlock(GameObject originalGameObject)
    {
        // Find the original gameObject
        for (int i = 0; i < myContent.childCount; i++)
        {
            // If the clone's saved object is the same as the one in the content
            if (originalGameObject == myContent.GetChild(i).gameObject)
            {
                try
                {
                    // Cache that canvas group for the gameObject in the content
                    CanvasGroup canvasGroup = myContent.GetChild(i).GetComponent<CanvasGroup>();

                    // Enable that gameObject in the content
                    canvasGroup.alpha = 1;
                    canvasGroup.blocksRaycasts = true;

                    // Dereference myClone for the word block
                    canvasGroup.GetComponent<NotebookWordBlock>().myClone = null;

                    // Stop the search
                    break;
                }
                catch
                {
                    Debug.Log("The gameobject in content does not have a canvas group");
                }
            }
        }
    }
}
