using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : Menu
{
    // Inventory Grouper in this case
    [SerializeField] GameObject inventoryUI, bagSlotsUI;

    public void MenuToggle()
    {
        // If the menu is currently deactivated
        if (inventoryUI.activeSelf == false)
        {
            // Activate the menus
            inventoryUI.SetActive(true);
            bagSlotsUI.SetActive(true);
        }
        // If the menu is currently activated
        else
        {
            // Deactivate the menus
            inventoryUI.SetActive(false);
            bagSlotsUI.SetActive(false);
        }
    }
}
