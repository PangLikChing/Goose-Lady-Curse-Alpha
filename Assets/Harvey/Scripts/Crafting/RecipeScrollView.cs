using Project.Build.Commands;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script is responsible for intialize the recipes in the crafting menu
/// </summary>
/// 

public class RecipeScrollView : MonoBehaviour
{
    [SerializeField] CraftingRecipe[] recipes;

    public Transform recipeButton;

    [SerializeField] Transform recipeDisplayContent;

    [HideInInspector] public string recipesFolderPath = "";

    void Start()
    {
        // Initialize
        //recipesFolderPath = "Scriptable Objects/Recipes";
    }

    public void ShowRecipes()
    {
        // For every child element currently in the content
        for (int i = 0; i < recipeDisplayContent.childCount; i++)
        {
            // Destory that gameObject
            Destroy(recipeDisplayContent.GetChild(i).gameObject);
        }

        // Get all the recipes in that category
        recipes = Resources.LoadAll<CraftingRecipe>(recipesFolderPath).ToArray();

        // For every recipe
        for (int i = 0; i < recipes.Length; i++)
        {
            // Create a new button
            Transform button = Instantiate(recipeButton, recipeDisplayContent);

            // Assign item that the button is responsible for
            button.GetComponent<RecipeButton>().item = recipes[i].item;

            // Initialize button's UI elements
            button.GetChild(0).GetComponent<TMP_Text>().text = recipes[i].recipeName;
            button.GetChild(1).GetComponent<Image>().sprite = recipes[i].item.itemIcon;
        }
    }
}
