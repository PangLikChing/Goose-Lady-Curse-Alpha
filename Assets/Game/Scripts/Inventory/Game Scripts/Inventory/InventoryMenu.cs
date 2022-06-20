using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InventoryHotKeyHandler))]
public class InventoryMenu : Menu
{
    InventoryHotKeyHandler inventoryHotKeyHandler;

    // Inventory Menu UI in this case
    [SerializeField] GameObject inventoryUI;

    public void MenuToggle()
    {
        // Cache the InventoryHotKeyHandler in the inventory menu gameObject
        inventoryHotKeyHandler = GetComponent<InventoryHotKeyHandler>();

        // If the menu is currently deactivated
        if (inventoryUI.activeSelf == false)
        {
            // Activate the menu
            inventoryHotKeyHandler.OpenInventory();
        }
        // If the menu is currently activated
        else
        {
            // Deactivate the menu
            inventoryHotKeyHandler.CloseInventory();
        }
    }
}
