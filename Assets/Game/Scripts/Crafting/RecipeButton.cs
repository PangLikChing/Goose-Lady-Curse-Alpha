using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RecipeButton : MonoBehaviour
{
    [SerializeField] CraftingManager craftingManager;

    [HideInInspector] public CraftingRecipe recipe;

    void Start()
    {
        craftingManager = FindObjectOfType<CraftingManager>();
    }

    public void SetItem()
    {
        // Set recipe
        craftingManager.ChangeSelectedItem(recipe);

        // Show descriptions and reagents and stuff
    }
}
