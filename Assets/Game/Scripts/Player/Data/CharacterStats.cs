using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterStats : MonoBehaviour
{
    [Header("General Stats")]
    public List<Stat> statList;
    [Header("Health Tracking")]
    public SurvivalStat health;
    public UnityEvent playerDied;

    private bool isDead;
    private void Start()
    {
        InitializeCharacterStats();
    }

    public void InitializeCharacterStats()
    {
        isDead = false;
        foreach (Stat stat in statList)
        {
            stat.Initialize();
        }
    }

    private void Update()
    {
        if (health.currentValue <= 0 && !isDead)
        {
            playerDied.Invoke();
            isDead = true;
        }
        if (!isDead)
        {
            foreach (Stat stat in statList)
            {
                stat.StatUpdate();
            }
        }
    }
}
