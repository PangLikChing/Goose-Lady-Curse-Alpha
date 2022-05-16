using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Item Effects/Change Thrist")]
public class ChangeThrist : ItemEffect
{
    [SerializeField] float changeThrist = 0;

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}