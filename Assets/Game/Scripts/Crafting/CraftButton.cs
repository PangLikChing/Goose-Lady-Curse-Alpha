using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CraftButton : MonoBehaviour
{
    void Start()
    {
        // Initialize
        GetComponent<Button>().interactable = false;
    }

    // Method to craft an item
    // Here assume that the player can only craft if it has enough reagents
    public void CraftItem()
    {
        // Get the current recipe
        CraftingRecipe recipe = CraftingManager.Instance.craftingRecipe;

        // Grab the current stackNumber that the player input
        int stackNumber = int.Parse(CraftingManager.Instance.craftingNumberInputField.text);

        // If there is an item seclected, and the input stack number is greater than 0
        if (recipe != null && stackNumber > 0)
        {
            // Consume reagent
            // For every reagent
            for (int i = 0; i < recipe.reagents.Length; i++)
            {
                // Consume that reagent
                CraftingManager.Instance.playerInventory.ConsumeItem(recipe.reagents[i].item, recipe.reagents[i].requiredAmount * stackNumber);
            }

            // Add that stackNumber amount of that item to the inventory
            CraftingManager.Instance.playerInventory.AddItem(recipe.item, stackNumber);
        }
    }
}
