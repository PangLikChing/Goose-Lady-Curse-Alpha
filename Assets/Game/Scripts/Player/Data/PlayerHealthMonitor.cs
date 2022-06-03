using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthMonitor : MonoBehaviour
{
    public SurvivalStat health;
    public UnityEvent playerDied;

    private bool isDead;
    // Update is called once per frame
    void Update()
    {
        if (health.currentValue <= 0&&!isDead)
        {
            playerDied.Invoke();
            isDead = true;
        }
    }

    public void ResetState()
    {
        isDead = false;
    }
}
