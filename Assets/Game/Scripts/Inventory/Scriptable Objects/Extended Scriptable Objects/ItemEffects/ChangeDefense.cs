using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Consumable/Consumable Effect/Change Defense")]
public class ChangeDefense : ItemEffect
{
    [SerializeField] float changeDefense = 0;

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
