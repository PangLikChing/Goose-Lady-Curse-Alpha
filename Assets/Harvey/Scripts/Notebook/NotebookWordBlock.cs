using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class NotebookWordBlock : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Transform DraggableClonePrefeb;
    public NotebookDraggableWordBlock myClone;

    [SerializeField] Image myImage;
    [SerializeField] TMP_Text myTextField;

    RectTransform rectTransform;
    CanvasGroup canvasGroup;

    [HideInInspector] public Canvas canvas;

    void Start()
    {
        // Initialize
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Start dragging");

        // If I am dragging with my left mouse button down
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Make it so that it is not interactable with raycast when dragging
            canvasGroup.blocksRaycasts = false;

            //test

            // Instantiate a dragable word block
            myClone = Instantiate(DraggableClonePrefeb, canvas.transform).GetComponent<NotebookDraggableWordBlock>();

            // Snap myCLone's position to this transform's position to create the illusion of they are the same object
            myClone.transform.position = transform.position;

            // Assign sprite and word for the clone
            myClone.myImage.sprite = myImage.sprite;
            myClone.myTextField.text = myTextField.text;

            // Hide this gameObject
            canvasGroup.alpha = 0;

            // Disable the drag-ability of this word block
            canvasGroup.blocksRaycasts = false;

            //test
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");

        // If I am dragging with my left mouse button down
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Move the dragged object with mouse
            myClone.rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Stopped dragging");

        // If I am dropping with a left mouse button
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // If the clone is not dropped on top of a dropping field
            if (myClone.transform.parent.GetComponent<NotebookDroppingField>() == null)
            {
                // Destroy the clone's gameObject
                Destroy(myClone.gameObject);

                // Show the word block again
                canvasGroup.alpha = 1;

                // Enable dragging of this word block
                canvasGroup.blocksRaycasts = true;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }
}
