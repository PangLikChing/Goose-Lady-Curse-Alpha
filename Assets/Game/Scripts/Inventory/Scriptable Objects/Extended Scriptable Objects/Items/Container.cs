using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This scriptable object stores the data of a container
/// </summary>

[CreateAssetMenu(menuName = "Item/Equipment/Container")]
public class Container : Equipment
{
    public UnityEvent<ItemSlot> equipBag;

    // volume is the number of items that the container can hold;
    public int volume = 1;

    // Equipping the bag if a bag slot is available
    public override void Use(ItemSlot itemSlot)
    {
        equipBag.Invoke(itemSlot);
    }
}
