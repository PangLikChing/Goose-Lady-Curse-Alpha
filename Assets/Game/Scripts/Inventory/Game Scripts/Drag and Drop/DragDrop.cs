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
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    [SerializeField] Canvas canvas;

    [SerializeField] int itemDropDistance = 5;
    
    [HideInInspector] public InventorySlot originalInventorySlot;

    public UnityEvent<Item, int> DropItem;

    void Start()
    {
        // Initialize
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        // Hard code this one, fix later
        canvas = transform.parent.parent.parent.GetComponent<InventoryGrouper>().canvas;
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
            // Reset blockRaycasts
            canvasGroup.blocksRaycasts = true;

            // If the item's parent is not an inventory slot at the end of drag
            if (transform.parent.GetComponent<InventorySlot>() == null)
            {
                // If the slotted item was moved
                if (originalInventorySlot != null)
                {
                    // Reset item's parent
                    transform.SetParent(originalInventorySlot.transform);



                    // Drop Item on Ground
                    DropItemOnGround();
                }

                // Reset item's position
                transform.localPosition = new Vector2(0, 0);
            }

            // Reset originalInventorySlot
            originalInventorySlot = null;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    void DropItemOnGround()
    {
        //// Assign the item and stack number to the item on the ground
        //item.GetComponent<ItemWrapper>().item = originalInventorySlot.slottedItem;
        //item.GetComponent<ItemWrapper>().stackNumber = originalInventorySlot.stackNumber;

        // Invoke an event for the player to drop off the item
        DropItem.Invoke(originalInventorySlot.slottedItem, originalInventorySlot.stackNumber);

        // Reset the original inventory slot
        originalInventorySlot.myInventory.itemList[originalInventorySlot.myBagIndex][originalInventorySlot.mySlotIndex].slottedItem = null;
        originalInventorySlot.myInventory.itemList[originalInventorySlot.myBagIndex][originalInventorySlot.mySlotIndex].stackNumber = 0;

        // Refresh that inventory slot
        originalInventorySlot.RefreshInventorySlot();
    }
}
