using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Consumable/Consumable Effect/Change Stamina Rate")]
public class ChangeStaminaRate : ItemEffect
{
    [SerializeField] float changeStaminaRate = 0;

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
