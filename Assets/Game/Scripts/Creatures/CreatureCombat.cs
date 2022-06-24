using Project.Build.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is an entirely temporary solution to AI combat module
/// final solution require deeper integration with its state machine
/// </summary>
public class CreatureCombat : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float range;
    [SerializeField]
    private float interval;
    [SerializeField]
    private float defence;
    [SerializeField, ReadOnly]
    private float intervalCounter;
    [SerializeField, ReadOnly]
    private bool attacking = false;
    private Predator predator;
    private void Start()
    {
        intervalCounter = 0;
        currentHealth = maxHealth;
        predator = GetComponent<Predator>();
    }

    private void Update()
    {
        AttackTarget(GameObject.FindGameObjectWithTag("Player").transform);
        if (currentHealth <= 0)
        {
            Destroy(gameObject, 0.5f);
        }
    }

    public void AttackTarget(Transform target)
    {
        if (intervalCounter > 0)
        {
            intervalCounter -= Time.deltaTime;
            return;
        }

        if (target.TryGetComponent<AvatarCombat>(out AvatarCombat combat)&& Vector3.Distance(target.transform.position,transform.position)<=range)
        {
            combat.TakeDamage(damage);
            intervalCounter = interval;
            //attacking = true;
        }
    }

    public void TakeDamage(float damage)
    {
        float actualDamage = 0;
        actualDamage = Mathf.Clamp(damage, 0, damage - defence);
        currentHealth -= actualDamage;
    }
    //invoked when the animation is complete
    public void AttackComplete()
    {
        attacking = false;
    }
}
