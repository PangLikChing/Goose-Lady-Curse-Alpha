using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RecipeButton : MonoBehaviour
{
    [SerializeField] CraftButton craftButton;

    [HideInInspector] public Item item;

    void Start()
    {
        craftButton = FindObjectOfType<CraftButton>();
    }

    public void SetItem()
    {
        // Set item
        craftButton.item = item;
        
        // Show descriptions and reagents and stuff
    }
}
