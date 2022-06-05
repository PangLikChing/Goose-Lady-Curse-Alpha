using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingMenuHotKeyHandler : MonoBehaviour
{
    public InputReader reader;
    public GameObject craftingMenu;
    private void OnEnable()
    {
        reader.OpenCraftingMenuEvent += OpenInventory;
    }

    private void OnDisable()
    {
        reader.OpenCraftingMenuEvent -= OpenInventory;
        reader.OpenCraftingMenuEvent -= CloseInventory;
    }

    public void OpenInventory()
    {
        craftingMenu.SetActive(true);
        reader.OpenCraftingMenuEvent += CloseInventory;
        reader.OpenCraftingMenuEvent -= OpenInventory;
    }

    public void CloseInventory()
    {
        craftingMenu.SetActive(false);
        reader.OpenCraftingMenuEvent += OpenInventory;
        reader.OpenCraftingMenuEvent -= CloseInventory;
    }
}
