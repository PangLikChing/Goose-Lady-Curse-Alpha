using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class BagSlotsUI : MonoBehaviour
{
    RectTransform rectTransform;

    public Canvas canvas;

    [SerializeField] InventoryGrouper inventoryGrouper;

    [SerializeField] Transform bagSlotPrefeb;

    [SerializeField] Inventory playerInventory;

    void Awake()
    {
        // Initialize
        rectTransform = GetComponent<RectTransform>();
    }

    void OnEnable()
    {
        // Calculate the bag slot's position in the scene
        rectTransform.anchoredPosition = new Vector2(-bagSlotPrefeb.GetComponent<RectTransform>().sizeDelta.x * 1.1f, inventoryGrouper.GetComponent<RectTransform>().anchoredPosition.y);

        // Instantiate a bag slot gameObject for every bag slot
        for (int i = 0; i < playerInventory.bags.Count; i++)
        {
            // Get the reference of the image component of that instantiated bag slot
            Transform slotTransform = Instantiate(bagSlotPrefeb, transform).transform;

            // Assign which bag theat bag slot is responsible for
            slotTransform.GetComponent<BagSlot>().bagIndex = i;
            slotTransform.GetChild(0).GetComponent<BagSlotDragDrop>().bagIndex = i;

            // Assign which inventory theat bag slot is responsible for
            slotTransform.GetComponent<BagSlot>().playerInventory = playerInventory;

            // Set the slotted image's sprite to the bag image
            slotTransform.GetComponent<BagSlot>().AssignBagImage();
        }
    }

    void OnDisable()
    {
        // Destory all child gameObject
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
