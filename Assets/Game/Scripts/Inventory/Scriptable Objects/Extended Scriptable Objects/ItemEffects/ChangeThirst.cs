using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Consumable/Consumable Effect/Change Thirst")]
public class ChangeThirst : ItemEffect
{
    [SerializeField] float changeThirst = 0;

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}