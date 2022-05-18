using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Consumable/Consumable Effect/Change Hunger")]
public class ChangeHunger : ItemEffect
{
    [SerializeField] float changeHunger = 0;

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
