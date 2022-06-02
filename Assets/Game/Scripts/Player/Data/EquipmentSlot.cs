using Project.Build.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Equipment Slot", menuName = "Character/Equipment Slot")]
public class EquipmentSlot : ScriptableObject
{
    [ReadOnly]public Equipment equipment;
    [ReadOnly]public bool isOccupied;
    public UnityEvent OnEquip;
    public UnityEvent<Item,int> OnUnequip;

    public void Equip(Equipment equipment)
    {
        if (isOccupied)
        {
            UnEquip();
        }
        isOccupied = true;
        this.equipment = equipment;
        OnEquip.Invoke();
        //Apply item bounus

    }

    public void UnEquip()
    {
        isOccupied = false;
        OnUnequip.Invoke(equipment, 1);
        equipment = null;
        //Remove item bonus
    }
}
