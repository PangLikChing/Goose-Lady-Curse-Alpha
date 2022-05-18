using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This scriptable object stores the data of an equipment
/// </summary>

[CreateAssetMenu(menuName = "Item/Equipment")]
public class Equipment : Item
{
    // When this scriptable object is created
    void Awake()
    {
        // Set the maximum stack number to 1
        maxStackNumber = 1;
    }
}
