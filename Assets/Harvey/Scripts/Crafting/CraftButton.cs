using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CraftButton : MonoBehaviour
{
    [HideInInspector] public Item item;

    [SerializeField] TMP_InputField inputField;

    [SerializeField] Inventory playerInventory;

    void Start()
    {
        // Initialize
        GetComponent<Button>().interactable = false;
    }

    // If the player can pick up items during crafting, change this to fixed update
    public void CheckCraftable(Item selectedItem)
    {
        // Set the item to the selected item
        item = selectedItem;

        // If there is no item seclected or the input stack number is less than or equals to 0
        if (item == null || int.Parse(inputField.text) <= 0)
        {
            // Set the button to not interactable
            GetComponent<Button>().interactable = false;
        }
        else
        {
            // Set the button to interactable
            GetComponent<Button>().interactable = true;
        }
    }

    public void CraftItem()
    {
        // Grab the current stackNumber that the player input
        int stackNumber = int.Parse(inputField.text);

        // If there is an item seclected and the input stack number is greater than 0
        if (item != null && stackNumber > 0)
        {
            // Add that stackNumber amount of that item to the inventory
            playerInventory.AddItem(item, stackNumber);
        }
    }
}
