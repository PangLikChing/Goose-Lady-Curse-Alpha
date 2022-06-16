using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Chest is the item that players can put in the world for holding items
/// </summary>

public class Chest : MonoBehaviour
{
    [SerializeField] Container myContainer = null;

    // Method to display the chest's inventory
    private void OpenChest()
    {
        Debug.Log($"Opening {this.name} 's container.");
    }
}
