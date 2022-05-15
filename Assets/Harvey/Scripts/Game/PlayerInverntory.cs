using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PlayerInventory is the bags that the player is carrying
/// </summary>

public class PlayerInverntory : MonoBehaviour
{
    [SerializeField] Inventory myInventory;

    // Method to display player's inventory
    private void OpenInventory()
    {
        Debug.Log($"Opening {this.name} 's inventory.");
    }
}
