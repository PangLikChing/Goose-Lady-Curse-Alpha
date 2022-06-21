using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup), typeof(Image))]
public class EquipmentDragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    int UILayer;
    RectTransform rectTransform;
    CanvasGroup canvasGroup;

    public UnityEvent<Item, int> unequipByRightClick;

    [HideInInspector] public Transform originalParentTransform;

    [HideInInspector] public int bagIndex = 0;

    [SerializeField] Canvas canvas;

    void Start()
    {
        // Initialize
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        UILayer = LayerMask.NameToLayer("UI");
        originalParentTransform = transform.parent;
    }

    public void EnableDragDrop()
    {
        // Enable the drag-ability
        canvasGroup.blocksRaycasts = true;

        // Show the equipment item
        canvasGroup.alpha = 1;
    }

    public void DisableDragDrop()
    {
        // Disable the drag-ability
        canvasGroup.blocksRaycasts = false;

        // Hide the equipment item
        canvasGroup.alpha = 0;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // If I am dragging with my left mouse button down
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Make it so that it is not interactable with raycast when dragging
            canvasGroup.blocksRaycasts = false;

            // Change the parent to the canvas so that it will not be blocked by other slots
            transform.SetParent(canvas.transform);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // If I am dragging with my left mouse button down
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Move the dragged object with mouse
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // If I am dropping with a left mouse button
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Reset blockRaycasts to allow player to drag the bag icon again
            canvasGroup.blocksRaycasts = true;

            // Reset the parent of this bag image to the original parent so that it can go back to its place
            transform.SetParent(originalParentTransform);

            // Position the transform to its parent's center
            transform.localPosition = new Vector2(0, 0);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // If that is a right-click
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            // If there is an equipment in the slot
            if (GetComponent<EquipmentSlotController>().targetSlot.isOccupied == true)
            {
                // Throw a debug message
                Debug.Log("Should do something");

                // Unequip the equipment
                unequipByRightClick.Invoke(GetComponent<EquipmentSlotController>().targetSlot.equipment, 1);
            }
        }
    }
}
