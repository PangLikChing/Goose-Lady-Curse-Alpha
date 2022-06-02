using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CraftingManager : Singleton<CraftingManager>
{
    Item selectedItem = null;

    public TMP_InputField craftingNumberInputField;

    public Inventory playerInventory;

    [HideInInspector] public CraftingRecipe craftingRecipe;

    [SerializeField] TMP_Text itemNameText, itemDescriptionText;

    [SerializeField] Transform reagentBlockPrefeb, reagentMenuContent;

    [SerializeField] CraftButton craftButton;

    //temp
    //void FixedUpdate()
    //{
    //    // If there is a recipe
    //    if (craftingRecipe != null)
    //    {
    //        // Check if I can craft it
    //        CheckCraftable(craftingRecipe);
    //    }
    //}
    //temp

    public void CheckReagents()
    {
        // If there is a recipe
        if (craftingRecipe != null)
        {
            // Check if I can craft it
            CheckCraftable(craftingRecipe);
        }
    }

    public void ChangeSelectedItem(CraftingRecipe recipe)
    {
        // Assign recipe
        craftingRecipe = recipe;

        // Set the item to be the selected item
        selectedItem = recipe.item;

        // Set the itemNameText and itemDescriptionText for that item in the crafting panel
        itemNameText.text = selectedItem.itemDisplayName;
        itemDescriptionText.text = recipe.description;

        // Delete all reagent blocks currently in the reagent content
        // For every element in the reagent menu content
        for (int i = 0; i < reagentMenuContent.childCount; i++)
        {
            // Disable that gameObject
            reagentMenuContent.GetChild(i).gameObject.SetActive(false);
        }

        // Display the required reagents
        for (int i = 0; i < recipe.reagents.Length; i++)
        {
            // Enable that gameObject
            reagentMenuContent.GetChild(i).gameObject.SetActive(true);

            // Set the image for that reagent
            reagentMenuContent.GetChild(i).GetChild(0).GetComponent<Image>().sprite = recipe.reagents[i].item.itemIcon;

            // Set the required amount text to reflect that required amount of the reagent
            reagentMenuContent.GetChild(i).GetChild(3).GetComponent<TMP_Text>().text = recipe.reagents[i].requiredAmount.ToString();

            // Update the reagents
            CheckReagents();
        }
    }

    // If the player can pick up items during crafting, change this to fixed update
    public void CheckCraftable(CraftingRecipe recipe)
    {
        // Set the item to the selected item
        craftingRecipe = recipe;

        // If there is no reagent needed for that craft
        if (recipe.reagents.Length == 0)
        {
            // Set the button to interactable
            craftButton.GetComponent<Button>().interactable = true;

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
        if (recipe == null || int.Parse(craftingNumberInputField.text) <= 0 || !ReagentPresent(int.Parse(craftingNumberInputField.text)))
        {
            // Set the button to not interactable
            craftButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            // Set the button to interactable
            craftButton.GetComponent<Button>().interactable = true;
        }
    }

    // Method to check if all required reagents are presented
    private bool ReagentPresent(int stackNumber)
    {
        // For every reagent
        for (int i = 0; i < reagentMenuContent.childCount; i++)
        {
            // Cache the current reagent block
            Transform currentReagentBlock = reagentMenuContent.GetChild(i).transform;

            // If the reagent block is active aka a reagent is on the recipe
            if (currentReagentBlock.gameObject.activeSelf == true)
            {
                // If the acquried reagent is less than the required amount of reagent
                if (int.Parse(currentReagentBlock.GetChild(1).GetComponent<TMP_Text>().text) < int.Parse(currentReagentBlock.GetChild(3).GetComponent<TMP_Text>().text) * stackNumber)
                {
                    // Return false
                    return false;
                }
            }
            // Else if the reagent block is not responsible for the reagent on the recipe
            else
            {
                // Stop the check
                break;
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
