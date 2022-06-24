using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is responsible to changing the recipe resources folder path when the player choose to craft in different places
/// </summary>

public class CraftingLocation : MonoBehaviour
{
    public string path = "";

    [SerializeField] RecipeScrollView recipeScrollView;

    public void OnClick()
    {
        // Change the path 
        recipeScrollView.recipesFolderPath = path;

        // Display the recipes in that category
        recipeScrollView.ShowRecipes();
    }
}
