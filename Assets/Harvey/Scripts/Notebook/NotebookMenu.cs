using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotebookMenu : Menu
{
    // temp
    // Inventory Menu UI in this case
    [SerializeField] GameObject notebookUI;

    public void MenuToggle()
    {
        // If the menu is currently deactivated
        if (notebookUI.activeSelf == false)
        {
            // Activate the menu
            notebookUI.SetActive(true);
        }
        // If the menu is currently activated
        else
        {
            // Deactivate the menu
            notebookUI.SetActive(false);
        }
    }
    //temp
}
