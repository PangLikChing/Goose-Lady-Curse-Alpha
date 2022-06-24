using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

/// <summary>
/// This script is responsible for handling the drag and drop of an item in the inventory
/// </summary>

[RequireComponent(typeof(CanvasGroup))]
public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    int UILayer;
    RectTransform rectTransform;
    CanvasGroup canvasGroup;

    [SerializeField] Canvas canvas;

    [HideInInspector] public InventorySlot originalInventorySlot;

    public UnityEvent<Item, int> DropItem;

    void Start()
    {
        // Initialize
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        UILayer = LayerMask.NameToLayer("UI");

        // Hard code this one, fix later
        canvas = transform.parent.parent.parent.GetComponent<InventoryGrouper>().canvas;
    }

    // Returns 'true' if we touched or hovering on Unity UI element
    private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];

            if (curRaysastResult.gameObject.layer == UILayer)
            {
                return true;
            }
        }
        return false;
    }

    // Returns 'true' if we touched or hovering on an inventory slot
    private bool IsPointerOverInventorySlot(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int i = 0; i < eventSystemRaysastResults.Count; i++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[i];

            if (curRaysastResult.gameObject.GetComponent<InventorySlot>() != null)
            {
                return true;
            }
        }
        return false;
    }

    // Gets all event system raycast results of current mouse or touch position.
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);

        eventData.position = Mouse.current.position.ReadValue();

        List<RaycastResult> raysastResults = new List<RaycastResult>();

        EventSystem.current.RaycastAll(eventData, raysastResults);

        return raysastResults;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // If I am dragging with my left mouse button down
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Make it so that it is not interactable with raycast when dragging
            canvasGroup.blocksRaycasts = false;

            // Set the originalInventorySlot to the one that is holding the Item
            originalInventorySlot = transform.parent.GetComponent<InventorySlot>();

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
            // If the cursor is not targeting a gameObject in the UI layer at the end of drag, aka out of the inventory
            if (!IsPointerOverUIElement(GetEventSystemRaycastResults()))
            {
                // If the slotted item was moved
                if (originalInventorySlot != null)
                {
                    // Reset item's parent
                    transform.SetParent(originalInventorySlot.transform);

                    // Drop the item on Ground
                    DropItemOnGround();
                }

                // Reset item's position to the centre of the original inventory slot
                transform.localPosition = new Vector2(0, 0);
            }
            else
            {
                // Reset blockRaycasts to allow player to drag the item again
                canvasGroup.blocksRaycasts = true;

                // If the cursor if not targeting a inventory slot
                if (!IsPointerOverInventorySlot(GetEventSystemRaycastResults()))
                {
                    // Reset item's parent
                    transform.SetParent(originalInventorySlot.transform);

                    // Reset item's position to the centre of the original inventory slot
                    transform.localPosition = new Vector2(0, 0);
                }
            }

            // Updates the inventory slot
            originalInventorySlot.RefreshInventorySlot();

            // Reset originalInventorySlot
            originalInventorySlot = null;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    void DropItemOnGround()
    {
        // Invoke an event for the player to drop off the item
        DropItem.Invoke(originalInventorySlot.slottedItem, originalInventorySlot.stackNumber);

        // Reset the original inventory slot
        originalInventorySlot.myInventory.itemList[originalInventorySlot.myBagIndex][originalInventorySlot.mySlotIndex].slottedItem = null;
        originalInventorySlot.myInventory.itemList[originalInventorySlot.myBagIndex][originalInventorySlot.mySlotIndex].stackNumber = 0;
    }
}
