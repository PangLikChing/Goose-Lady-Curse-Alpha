using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CraftButton : MonoBehaviour
{
    [HideInInspector] public Item item;

    [SerializeField] Inventory playerInventory;

    public void CraftItem()
    {
        // Add that stackNumber amount of that item to the inventory
        playerInventory.AddItem(item, 1);
    }
}
