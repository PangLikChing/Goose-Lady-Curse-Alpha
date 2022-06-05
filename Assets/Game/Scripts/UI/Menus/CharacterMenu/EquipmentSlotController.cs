using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlotController : MonoBehaviour
{
    public EquipmentSlot targetSlot;
    public Image itemIcon;
    private void OnEnable()
    {
        targetSlot.OnEquip.AddListener(ChangeIcon);
        targetSlot.OnUnequip.AddListener(ClearIcon);
    }

    private void OnDisable()
    {
        targetSlot.OnEquip.RemoveListener(ChangeIcon);
        targetSlot.OnUnequip.RemoveListener(ClearIcon);
    }

    private void ChangeIcon()
    {
        itemIcon.sprite = targetSlot.equipment.itemIcon;
    }

    private void ClearIcon(Item equipment,int stack)
    {
        itemIcon.sprite = null;
    }
}
