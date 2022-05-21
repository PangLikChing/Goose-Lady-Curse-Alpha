using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Consumable/Consumable Effect/Change Body Temperature")]
public class ChangeBodyTemperature : ItemEffect
{
    [SerializeField] float changeBodyTemperature = 0;

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
