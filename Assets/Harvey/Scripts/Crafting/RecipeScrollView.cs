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

    [ReadOnly] public string recipesFolderPath = "";

    public Transform recipeButton;

    [SerializeField] Transform recipeDisplayContent;

    void Start()
    {
        // Initialize
        recipesFolderPath = "Scriptable Objects/Recipes";

        recipes = Resources.LoadAll<CraftingRecipe>(recipesFolderPath).ToArray();

        for (int i = 0; i < recipes.Length; i++)
        {
            Debug.Log(i);
            Transform button = Instantiate(recipeButton, recipeDisplayContent);
            button.GetChild(0).GetComponent<TMP_Text>().text = recipes[i].recipeName;
            button.GetChild(1).GetComponent<Image>().sprite = recipes[i].item.itemIcon;
        }
    }
}
