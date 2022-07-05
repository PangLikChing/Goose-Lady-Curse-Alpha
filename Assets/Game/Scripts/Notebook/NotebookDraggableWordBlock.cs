using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Project.Build.Commands;

/// <summary>
/// Behaviour script for draggable clone block for the notebook menu
/// </summary>

[RequireComponent(typeof(CanvasGroup))]
public class NotebookDraggableWordBlock : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Image myImage;
    public TMP_Text myTextField;

    [HideInInspector][ReadOnly] public Transform originalParent;
    [HideInInspector] public GameObject myOriginalGameObject;
    [HideInInspector] public NotebookReturnDroppingField returnDroppingField;
    [HideInInspector] public Canvas canvas;
    [HideInInspector] public CanvasGroup canvasGroup;
    [HideInInspector] public RectTransform rectTransform;

    void Awake()
    {
        // Initialize
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Turn off the blockRaycast for this block to allow dropping
        canvasGroup.blocksRaycasts = false;

        // Remember which dropping field this block was in
        originalParent = transform.parent;

        // Set the parent to the canvas for better visual
        transform.parent = canvas.transform;

        // Safety measure, see if the return dropping field is null
        if (returnDroppingField != null)
        {
            // Enable to drop-ability of the return dropping field
            returnDroppingField.gameObject.SetActive(true);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");

        // If I am dragging with my left mouse button down
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Move the dragged object with mouse
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");

        // Reset blockRaycast for this block to allow dragging
        canvasGroup.blocksRaycasts = true;

        // Safety measure, see if the return dropping field is null
        if (returnDroppingField != null)
        {
            // Enable to drop-ability of the return dropping field
            returnDroppingField.gameObject.SetActive(false);
        }

        // If the parent of this block is still the canvas, aka didn't drop to the return field
        if (transform.parent == canvas.transform)
        {
            // Reset parent to the original dropping field
            transform.SetParent(originalParent);

            // Return to the centre of the original dropping field
            transform.localPosition = new Vector2(0, 0);

            // Reset original parent to prevent weird bugs
            originalParent = null;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }
}
