using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CraftButton : MonoBehaviour
{
    public UnityEvent<Item, int> craftEvent, consumeReagentEvent;

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
            // temp
            // For the amount of item that the player want to craft
            for (int i = 0; i < stackNumber; i++)
            {
                // Check if the inventory is full here

                // Add that 1 of that item to the inventory
                craftEvent.Invoke(recipe.item, 1);

                // Consume reagent
                // For every reagent
                for (int j = 0; j < recipe.reagents.Length; j++)
                {
                    // Consume that reagent
                    consumeReagentEvent.Invoke(recipe.reagents[j].item, recipe.reagents[j].requiredAmount);
                }
            }
            // temp

            // Updates the reagents
            CraftingManager.Instance.CheckReagents();
        }
    }
}
