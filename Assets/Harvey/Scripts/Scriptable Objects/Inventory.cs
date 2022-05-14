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
    [SerializeField] private List<Container> bagSlots = new List<Container>();
}
