using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public SurvivalStat health;
    public SurvivalStat stamina;
    public SurvivalStat thirst;
    public SurvivalStat hunger;
    public SurvivalStat temperature;

    private void Start()
    {
        InitializeCharacterStats();
    }

    public void InitializeCharacterStats()
    {
        health.Initialize();
        stamina.Initialize();
        thirst.Initialize();
        hunger.Initialize();
        temperature.Initialize();
    }

    private void Update()
    {
        health.StatUpdate();
        stamina.StatUpdate();
        thirst.StatUpdate();
        hunger.StatUpdate();
        temperature.StatUpdate();
    }
}
