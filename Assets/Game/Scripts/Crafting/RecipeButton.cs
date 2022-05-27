using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RecipeButton : MonoBehaviour
{
    [HideInInspector] public CraftingRecipe recipe;

    public void SetItem()
    {
        // Set recipe
        CraftingManager.Instance.ChangeSelectedItem(recipe);
    }
}
