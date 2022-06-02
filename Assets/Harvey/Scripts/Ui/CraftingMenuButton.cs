using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingMenuButton : MonoBehaviour
{
    [SerializeField] GameObject craftingMenu;

    public void OnClick()
    {
        // If the crafting menu is active
        if (craftingMenu.activeSelf == true)
        {
            // Deactivate it
            craftingMenu.SetActive(false);
        }
        // If the crafting menu is not active
        else
        {
            // Activate it
            craftingMenu.SetActive(true);
        }
    }
}
