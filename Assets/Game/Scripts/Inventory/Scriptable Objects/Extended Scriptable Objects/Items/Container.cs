using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This scriptable object stores the data of a container
/// </summary>

[CreateAssetMenu(menuName = "Item/Equipment/Container")]
public class Container : Equipment
{
    // volume is the number of items that the container can hold;
    public int volume = 1;
}
