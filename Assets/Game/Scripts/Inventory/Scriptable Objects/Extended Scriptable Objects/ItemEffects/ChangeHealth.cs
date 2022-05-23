using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Consumable/Consumable Effect/Change Health")]
public class ChangeHealth : ItemEffect
{
    [SerializeField] float changeHealth = 0;

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
