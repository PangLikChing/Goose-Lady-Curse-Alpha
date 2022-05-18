using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Crafting/Recipe")]
public class CraftingRecipe : ScriptableObject
{
    public int recipeID = -1;

    public string recipeName = "";

    public Sprite recipeIcon = null;

    public List<Item> reagents = new List<Item>();
}
