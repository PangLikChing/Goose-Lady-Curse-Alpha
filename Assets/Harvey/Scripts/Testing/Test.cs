using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Just for testing
/// </summary>

public class Test : MonoBehaviour
{
    [SerializeField] Consumable testConsumable;

    [SerializeField] Container testContainer;

    [SerializeField] Inventory testInventory;

    [SerializeField] InventorySlot testInventorySlot;

    public List<ItemSlot> itemSlots = new List<ItemSlot>();

    [SerializeField] float testTimer = 0.0f;

    void Update()
    {
        if (testTimer >= 2.0f)
        {
            //testConsumable.heldItem = testInventorySlot.heldItem;
            //testConsumable.Consume();
            //testConsumable.heldItem = null;

            //testContainer.DisplayItems();

            //testInventory.DisplayContainers();

            testTimer = 0.0f;
        }
        else
        {
            testTimer += Time.deltaTime;
        }
    }
}
