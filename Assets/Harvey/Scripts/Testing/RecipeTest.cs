using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script is responsible for testing the recipe functions
/// </summary>
/// 

public class RecipeTest : MonoBehaviour
{
    public List<CraftingRecipe> recipes = new List<CraftingRecipe>();

    public Transform recipeButton;

    [SerializeField] Transform recipeDisplayContent;

    void Start()
    {
        for (int i = 0; i < recipes.Count; i++)
        {
            Debug.Log(i);
            Transform button = Instantiate(recipeButton, recipeDisplayContent);
            button.GetChild(0).GetComponent<TMP_Text>().text = recipes[i].recipeName;
            button.GetChild(1).GetComponent<Image>().sprite = recipes[i].recipeIcon;
        }
    }
}
