using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Consumable/Consumable Effect/Change Stamina")]
public class ChangeStamina : ItemEffect
{
    [SerializeField] float changeStamina = 0;

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
