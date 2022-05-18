using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Item Effects/Change Thirst Rate")]
public class ChangeThirstRate : ItemEffect
{
    [SerializeField] float changeThirstRate = 0;

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
