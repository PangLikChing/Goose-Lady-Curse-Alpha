using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Crafting/Recipe")]
public class CraftingRecipe : ScriptableObject
{
    public int recipeID = -1;

    public string recipeName = "";

    public Item item = null;

    public Item[] reagents;
}
