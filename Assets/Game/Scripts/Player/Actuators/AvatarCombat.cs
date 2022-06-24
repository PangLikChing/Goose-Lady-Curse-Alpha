using Project.Build.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AvatarCombat : MonoBehaviour
{
    public Stat attackDamage;
    public Stat attackRange;
    public Stat attackInterval;
    public Stat defence;
    public SurvivalStat health;

    [SerializeField, ReadOnly]
    private float intervalCounter;
    [SerializeField, ReadOnly]
    private Animator avatarAnimator;
    [SerializeField, ReadOnly]
    private bool attacking = false;
    private void Start()
    {
        intervalCounter = 0;
        avatarAnimator = GetComponent<Animator>();
    }

    public void AttackTarget(Transform target)
    {
        if (intervalCounter > 0 && !attacking)
        {
            intervalCounter -= Time.deltaTime;
            return;
        }

        if (target.TryGetComponent<CreatureCombat>(out CreatureCombat creatureCombat) && !attacking)
        {
            creatureCombat.TakeDamage(attackDamage.finalValue);
            avatarAnimator.SetTrigger("attack");
            intervalCounter = attackInterval.finalValue;
            attacking = true;
        }
    }

    public void TakeDamage(float damage)
    {
        float actualDamage = 0;
        actualDamage = Mathf.Clamp(damage, 0, damage - defence.finalValue);
        health.currentValue -= actualDamage;
    }

    public void AttackComplete()
    {
        attacking = false;
    }

    //public void CancelAttack()
    //{
    //    attacking = false;
    //    avatarAnimator.SetTrigger("cancel attack");
    //}
}
