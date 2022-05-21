using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Consumable/Consumable Effect/Change Body Temperature Rate")]
public class ChangeBodyTemperatureRate : ItemEffect
{
    [SerializeField] float changeTemperatureRate = 0;

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
