using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]
public class CreatureHealthBar : MonoBehaviour
{
    private Slider healthBar;
    public CreatureCombat combat;
    private void Start()
    {
        healthBar = GetComponent<Slider>();
    }

    private void Update()
    {
        healthBar.value = combat.currentHealth;
        transform.LookAt(transform.position+Camera.main.transform.rotation*Vector3.forward,Camera.main.transform.rotation*Vector3.up);
    }
}
