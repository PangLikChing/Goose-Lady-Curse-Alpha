using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Crafting/Recipe")]
public class CraftingRecipe : ScriptableObject
{
    public int recipeID = -1;

    public string recipeName = "";

    public Item item = null;

    [System.Serializable]
    public struct Reagents
    {
        public Item item;
        public int requiredAmount;
    }

    public Reagents[] reagents;

    [TextArea(5, 20)] public string description = "";
}
