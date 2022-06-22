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
    private bool notDialogPause;
    private bool isDead;
    private void Start()
    {
        InitializeCharacterStats();
        notDialogPause = true;
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
        if (notDialogPause)
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

    public void SetDialogPause(bool notDialogPause)
    {
        this.notDialogPause = notDialogPause;
    }
}
