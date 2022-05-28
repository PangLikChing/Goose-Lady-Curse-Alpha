using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHotKeyHandler : MonoBehaviour
{
    public InputReader reader;
    public GameObject InventoryUI;
    private void OnEnable()
    {
        reader.OpenInventoryEvent += OpenInventory;
    }

    private void OnDisable()
    {
        reader.OpenInventoryEvent -= OpenInventory;
        reader.OpenInventoryEvent -= CloseInventory;
    }

    public void OpenInventory()
    {
        InventoryUI.SetActive(true);
        reader.OpenInventoryEvent += CloseInventory;
        reader.OpenInventoryEvent -= OpenInventory;
    }

    public void CloseInventory()
    {
        InventoryUI.SetActive(false);
        reader.OpenInventoryEvent += OpenInventory;
        reader.OpenInventoryEvent -= CloseInventory;
    }
}
