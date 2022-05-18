using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This scriptable object stores the data of a player inventory
/// </summary>

[CreateAssetMenu(menuName = "Scriptable Objects/Inventory")]
public class Inventory : ScriptableObject
{
    // bagSlots is the bags that the player is holding
    [SerializeField] public List<Container> bagSlots = new List<Container>();

    // Debug
    public void DisplayContainers()
    {
        // For every element in bagSlots
        for (int i = 0; i < bagSlots.Count; i++)
        {
            // If an item exists in bagSlots[i]
            if (bagSlots[i] != null)
            {
                // Ask that container to display all items it holds
                bagSlots[i].DisplayItems();
            }
            // Else
            else
            {
                // Throw a debug message with null
                Debug.Log("Null\t");
            }
        }
    }
}
