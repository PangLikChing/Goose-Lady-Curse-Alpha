using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This scriptable object stores the data of a consumable
/// </summary>

[CreateAssetMenu(menuName = "Scriptable Objects/Consumable")]
public class Consumable : Item
{
    public List<ItemEffect> itemEffect = new List<ItemEffect>();

    public void Consume()
    {
        // For every item effects in the itemEffect list
        for (int i = 0; i < itemEffect.Count; i++)
        {
            // Conduct the effect
            itemEffect[i].UseItem();
        }

        // Decrease the number of item in the stack by 1
        stackNumber -= 1;

        // Should delete the item if stackNumber is 0

        // Throw a debug message
        Debug.Log($"{this.name}'s current stack number: {stackNumber}");
    }
}
