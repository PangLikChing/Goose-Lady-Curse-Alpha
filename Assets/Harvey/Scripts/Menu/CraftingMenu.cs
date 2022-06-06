using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingMenu : Menu
{
    [SerializeField] GameObject craftingUI;

    public void MenuToggle()
    {
        // If the menu is currently deactivated
        if (craftingUI.activeSelf == false)
        {
            // Activate the menu
            craftingUI.SetActive(true);
        }
        // If the menu is currently activated
        else
        {
            // Deactivate the menu
            craftingUI.SetActive(false);
        }
    }
}
