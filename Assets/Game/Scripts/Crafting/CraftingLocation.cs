using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This script is responsible to changing the recipe resources folder path when the player choose to craft in different places
/// </summary>

public class CraftingLocation : MonoBehaviour
{
    public UnityEvent<string> displayRecipes;

    public string path = "";

    public void DisplayRecipes()
    {
        // Ask the recipe scroll view to change the recipes that it displays
        displayRecipes.Invoke(path);
    }
}
