using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public List<Stat> statList;


    private void Start()
    {
        InitializeCharacterStats();
    }

    public void InitializeCharacterStats()
    {
        foreach (Stat stat in statList)
        {
            stat.Initialize();
        }
    }

    private void Update()
    {
        foreach (Stat stat in statList)
        {
            stat.StatUpdate();
        }
    }
}
