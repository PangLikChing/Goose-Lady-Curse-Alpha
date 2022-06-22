using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class EquipmentSlotController : MonoBehaviour
{
    public EquipmentSlot targetSlot;
    Image itemIcon;

    void Start()
    {
        // Initialize
        itemIcon = GetComponent<Image>();
    }

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
