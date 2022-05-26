using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : Singleton<CraftingManager>
{
    Item selectedItem = null;

    [SerializeField] TMP_Text itemNameText, itemDescriptionText;

    [SerializeField] Transform reagentBlockPrefeb, reagentMenuContent;

    [SerializeField] CraftButton craftButton;

    public void ChangeSelectedItem(CraftingRecipe recipe)
    {
        // Set the item to be the selected item
        selectedItem = recipe.item;

        // Set the itemNameText and itemDescriptionText for that item in the crafting panel
        itemNameText.text = selectedItem.itemDisplayName;
        itemDescriptionText.text = recipe.description;

        // Delete all reagent blocks currently in the reagent content
        // For every element in the reagent menu content
        for (int i = 0; i < reagentMenuContent.childCount; i++)
        {
            // Destory that gameObject
            Destroy(reagentMenuContent.GetChild(i).gameObject);
        }

        // Display the required reagents
        for (int i = 0; i < recipe.reagents.Length; i++)
        {
            // Instantiate a reagent block gameObject for that reagent
            Transform reagentBlock = Instantiate(reagentBlockPrefeb, reagentMenuContent);

            // Set the image for that reagent
            reagentBlock.GetChild(0).GetComponent<Image>().sprite = recipe.reagents[i].item.itemIcon;

            // Set the required amount text to reflect that required amount of the reagent
            reagentBlock.GetChild(3).GetComponent<TMP_Text>().text = recipe.reagents[i].requiredAmount.ToString();
        }

        // Check if the item is craftable or not
        craftButton.CheckCraftable(recipe.item);
    }
}
