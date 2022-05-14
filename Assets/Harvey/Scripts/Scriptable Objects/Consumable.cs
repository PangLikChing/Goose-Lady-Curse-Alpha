using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This scriptable object stores the data of a consumable
/// </summary>

[CreateAssetMenu(menuName = "Scriptable Objects/Consumable")]
public class Consumable : Item
{
    public void Consume()
    {
        // Decrease the number of item in the stack by 1
        stackNumber -= 1;

        // Throw a debug message
        Debug.Log($"{this.name}'s current stack number: {stackNumber}");
    }
}
