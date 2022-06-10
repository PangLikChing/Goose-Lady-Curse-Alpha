using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : Menu
{
    // Inventory Grouper in this case
    [SerializeField] GameObject inventoryUI;

    public void MenuToggle()
    {
        // If the menu is currently deactivated
        if (inventoryUI.activeSelf == false)
        {
            // Activate the menu
            inventoryUI.SetActive(true);
        }
        // If the menu is currently activated
        else
        {
            // Deactivate the menu
            inventoryUI.SetActive(false);
        }
    }
}
