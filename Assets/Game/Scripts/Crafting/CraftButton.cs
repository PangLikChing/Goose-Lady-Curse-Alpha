using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CraftButton : MonoBehaviour
{
    [HideInInspector] public CraftingRecipe recipe;

    [SerializeField] TMP_InputField inputField;

    [SerializeField] Transform reagentMenuContent;

    [SerializeField] Inventory playerInventory;

    void Start()
    {
        // Initialize
        GetComponent<Button>().interactable = false;
    }

    //temp
    void FixedUpdate()
    {
        // If there is a recipe
        if (recipe != null)
        {
            // Check if I can craft it
            CheckCraftable(recipe);
        }
    }
    //temp

    // If the player can pick up items during crafting, change this to fixed update
    public void CheckCraftable(CraftingRecipe craftingRecipe)
    {
        // Set the item to the selected item
        recipe = craftingRecipe;

        // If there is no reagent needed for that craft
        if (recipe.reagents.Length == 0)
        {
            // Set the button to interactable
            GetComponent<Button>().interactable = true;

            // Do not have to check anymore
            return;
        }

        // For every reagent
        for (int i = 0; i < recipe.reagents.Length; i++)
        {
            // Check the amount of that reagent in the inventory
            reagentMenuContent.GetChild(i).GetChild(1).GetComponent<TMP_Text>().text = SearchItem(recipe.reagents[i].item).ToString();
        }

        // If there is no item seclected or the input stack number is less than or equals to 0, or not all reagents are presented
        if (recipe == null || int.Parse(inputField.text) <= 0 || !ReagentPresent(int.Parse(inputField.text)))
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

    // Method to craft an item
    // Here assume that the player can only craft if it has enough reagents
    public void CraftItem()
    {
        // Grab the current stackNumber that the player input
        int stackNumber = int.Parse(inputField.text);

        // If there is an item seclected, and the input stack number is greater than 0
        if (recipe != null && stackNumber > 0)
        {
            // Consume reagent
            // For every reagent
            for (int i = 0; i < recipe.reagents.Length; i++)
            {
                // Consume that reagent
                playerInventory.ConsumeItem(recipe.reagents[i].item, recipe.reagents[i].requiredAmount * stackNumber);
            }

            // Add that stackNumber amount of that item to the inventory
            playerInventory.AddItem(recipe.item, stackNumber);
        }

        //// Check if the item is craftable again
        //CheckCraftable(recipe);
    }

    // Method to check if all required reagents are presented
    private bool ReagentPresent(int stackNumber)
    {
        // For every reagent
        for (int i = 0; i < reagentMenuContent.childCount; i++)
        {
            // Cache the current reagent block
            Transform currentReagentBlock = reagentMenuContent.GetChild(i).transform;

            // If the acquried reagent is less than the required amount of reagent
            if (int.Parse(currentReagentBlock.GetChild(1).GetComponent<TMP_Text>().text) < int.Parse(currentReagentBlock.GetChild(3).GetComponent<TMP_Text>().text) * stackNumber)
            {
                // Return false
                return false;
            }
        }

        // Return true
        return true;
    }

    // Method to search item in the player inventory
    int SearchItem(Item item)
    {
        // Initialize a temp int
        int count = 0;

        // For every bag
        for (int i = 0; i < playerInventory.itemList.Count; i++)
        {
            // For every slot
            for (int j = 0; j < playerInventory.itemList[i].Length; j++)
            {
                // If the slotted item in that slot is the same with the targeted item
                if (playerInventory.itemList[i][j].slottedItem == item)
                {
                    // Add the stack number to the temp int
                    count += playerInventory.itemList[i][j].stackNumber;
                }
            }
        }

        // Return the temp int
        return count;
    }
}
