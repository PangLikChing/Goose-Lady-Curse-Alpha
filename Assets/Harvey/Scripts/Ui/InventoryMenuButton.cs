using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenuButton : MonoBehaviour
{
    [SerializeField] GameObject inventoryGrouper;

    public void OnClick()
    {
        // If the inventory grouper is active
        if (inventoryGrouper.activeSelf == true)
        {
            // Deactivate it
            inventoryGrouper.SetActive(false);
        }
        // If the inventory grouper is not active
        else
        {
            // Activate it
            inventoryGrouper.SetActive(true);
        }
    }
}
